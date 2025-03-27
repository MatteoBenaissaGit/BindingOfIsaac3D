using System.Collections.Generic;
using MBLib.GameEventManager.Effects;
using MBLib.GameEventManager.Effects.Conditions;
using UnityEngine;

namespace MBLib.GameEventManager
{
    public class GameEventInstance
    {
        public List<GameEffect> GameEffects = new();
        public Dictionary<string, float> Timers = new();

        private Dictionary<string, object> _baseParameters = new();
        private Dictionary<string, object> _parameters = new();
        private int _currentEffect;
        
        public void SetParameters(params (string name, object value)[] parameters)
        {
            foreach (var parameter in parameters)
            {
                if (_parameters.ContainsKey(parameter.name))
                {
                    _parameters[parameter.name] = parameter.value;
                    continue;
                }
                _parameters.Add(parameter.name, parameter.value);
            }
        }
        
        public void SetBaseParameters(params (string name, object value)[] parameters)
        {
            foreach (var parameter in parameters)
            {
                _baseParameters.Add(parameter.name, parameter.value);
            }
        }

        public bool GetParameter<T>(string parameterName, out T @object) where T : new()
        {
            @object = default(T);
            if (_parameters.TryGetValue(parameterName, out object value) || _baseParameters.TryGetValue(parameterName, out value))
            {
                if (value is not T t)
                {
                    return false;
                }
                @object = t;
                return true;
            }
            Debug.LogError($"Parameter {parameterName} not found");
            return false;
        }

        public void Initialize()
        {
            _currentEffect = 0;
            _parameters.Clear();
            foreach (GameEffect gameEffect in GameEffects)
            {
                gameEffect.Initialize(this);
            }
            
            Timers.Clear();
        }

        private Stack<(ConditionalGameEffect condition, int index)> _conditions = new();
        public void Update()
        {
            //update timers
            List<string> keys = new List<string>(Timers.Keys);
            foreach (string key in keys)
            {
                Timers[key] -= Time.deltaTime;
            }

            //kill if no more effects
            if (_currentEffect >= GameEffects.Count)
            {
                GameEventsManager.KillEvent(this);
                return;
            }
            
            GameEffect effect = GameEffects[_currentEffect];

            //check for conditions
            if (effect is ConditionalGameEffect conditional)
            {
                int nextIndex = _currentEffect + 1;

                if (conditional.IsTrue(this) == false)
                {
                    for (int i = _currentEffect + 1; i < GameEffects.Count; i++)
                    {
                        if (GameEffects[i] is not End) continue;
                        nextIndex = i + 1;
                        break;
                    }
                }
                else
                {
                    _conditions.Push((conditional, _currentEffect));
                }
                
                _currentEffect = nextIndex;
                return;
            }
            if (effect is End && _conditions.Count > 0)
            {
                (ConditionalGameEffect condition, int index) condition = _conditions.Pop();
                if (condition.condition is While)
                {
                    _currentEffect = condition.index;
                    return;
                }
            }
            
            //execute effects
            if (effect.Execute(this) == false)
            {
                return;
            }
            if (effect is RestartEvent)
            {
                Initialize();
                return;
            }

            _currentEffect++;
        }
    }
}