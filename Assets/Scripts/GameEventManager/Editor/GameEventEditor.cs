using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBLib.GameEventManager;
using MBLib.GameEventManager.Attribute;
using MBLib.GameEventManager.Effects;
using MBLib.GameEventManager.Effects.Conditions;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Script.Editor
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : UnityEditor.Editor
    {
        private SerializedProperty _effects;
        private ReorderableList _list;
        private Type[] _types = new Type[]{};
        private int _conditionIncrement = 0;
        
        private void OnEnable()
        {
            _effects = serializedObject.FindProperty("GameEffects");

            _types = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                    from assemblyType in domainAssembly.GetTypes()
                    where assemblyType.IsSubclassOf(typeof(GameEffect))
                    select assemblyType).ToArray();

            _conditionIncrement = 0;
            _list = new ReorderableList(serializedObject, _effects, true, true, true, true);
            _list.drawElementCallback = DrawListItems;
            _list.drawHeaderCallback = DrawHeader;
            _list.onAddDropdownCallback = AddDropDown;
        }

        public override void OnInspectorGUI()
        {
            GameEvent gameEvent = target as GameEvent;

            TextBoxParameters(gameEvent);
            ClearParametersButton();

            _list.DoLayoutList();
            
            serializedObject.ApplyModifiedProperties();
        }

        private void ClearParametersButton()
        {
            if (GUILayout.Button("Clear Parameters"))
            {
                GameEvent gameEvent = target as GameEvent;
                if (gameEvent != null)
                {
                    gameEvent.ParametersKnown.Clear();
                    EditorUtility.SetDirty(gameEvent);
                }
            }
        }

        private void TextBoxParameters(GameEvent gameEvent)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("---Parameters---");
            foreach (string parameter in gameEvent.ParametersKnown)
            {
                stringBuilder.AppendLine(parameter);
            }
            
            string textBox = EditorGUILayout.TextField(stringBuilder.ToString(), GUILayout.Height(gameEvent.ParametersKnown.Count * 35));
        }

        private void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
        {
            GameEvent gameEvent = target as GameEvent;
            if (gameEvent == null) return;

            GameEffect feedback = gameEvent.GameEffects[index];
            if (feedback == null) return;

            SerializedProperty element = _effects.GetArrayElementAtIndex(index);
            SerializedProperty enabledProperty = element.FindPropertyRelative("Enabled");
            rect.x += 15;
            enabledProperty.boolValue = EditorGUI.Toggle(rect, GUIContent.none, enabledProperty.boolValue);

            rect.x += 30;
            string label = gameEvent.GameEffects[index].ToString();
            
            if (feedback is End)
            {
                _conditionIncrement--;
                if (_conditionIncrement < 0) _conditionIncrement = 0;
            }
            
            StringBuilder labelBuilder = new StringBuilder();
            if (_conditionIncrement > 0)
            {
                labelBuilder.Append("|");
                for (int i = 0; i < _conditionIncrement; i++)
                {
                    labelBuilder.Append("--");
                }
                labelBuilder.Append("  ");
            }
            labelBuilder.Append(label);
            label = labelBuilder.ToString();
            
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontStyle = FontStyle.Normal;
            labelStyle.normal.textColor = Color.white;
            labelStyle.alignment = TextAnchor.MiddleLeft;
            EditorGUI.LabelField(rect, label, labelStyle);
            
            if (feedback is ConditionalGameEffect)
            {
                _conditionIncrement++;
            }
            
            Rect side = rect;
            side.height = 20;
            side.x -= 45;
            side.width = 5;
            side.y += 1;

            Type type = feedback.GetType();
            Color color = new Color(1f, 1f, 1f, 0f);
            GameEffectColor colorAttribute = AttributeHelper.GetGameEffectColorAttribute(type);
            if (colorAttribute != null)
            {
                color = new Color(colorAttribute.Red / 255f, colorAttribute.Green / 255f, colorAttribute.Blue / 255f, 1f);
            }
            EditorGUI.DrawRect(side, color);

            if (isFocused == false && isActive == false)
            {
                return;
            }

            foreach (SerializedProperty child in GetChildren(element))
            {
                EditorGUILayout.PropertyField(child);
            }
        }

        private IEnumerable<SerializedProperty> GetChildren(SerializedProperty property)
        {
            SerializedProperty currentProperty = property.Copy();
            SerializedProperty nextProperty = property.Copy();
            nextProperty.Next(false);

            if (currentProperty.Next(true))
            {
                do
                {
                    if (SerializedProperty.EqualContents(currentProperty, nextProperty)) break;
                    yield return currentProperty;
                } 
                while (currentProperty.Next(false));
            }
        }

        private void DrawHeader(Rect rect)
        {
            
        }

        private void AddDropDown(Rect rect, ReorderableList list)
        {
            GenericMenu menu = new GenericMenu();

            foreach (Type type in _types)
            {
                if (type.IsAbstract) continue;
                
                GameEffectName nameAttribute = Attribute.GetCustomAttribute(type, typeof(GameEffectName)) as GameEffectName;
                string displayName = nameAttribute != null ? nameAttribute.Name : type.Name;
                
                menu.AddItem(new GUIContent(displayName), false, () =>
                {
                    _effects.arraySize++;
                    SerializedProperty newProp = _effects.GetArrayElementAtIndex(_effects.arraySize - 1);
                    newProp.managedReferenceValue = Activator.CreateInstance(type);
                    serializedObject.ApplyModifiedProperties();
                });
            }

            menu.ShowAsContext();
        }
    }
}