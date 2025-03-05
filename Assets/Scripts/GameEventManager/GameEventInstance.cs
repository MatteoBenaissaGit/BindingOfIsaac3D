using System.Collections;
using System.Collections.Generic;
using MBLib.GameEventManager.Effects;
using UnityEngine;

namespace MBLib.GameEventManager
{
    public class GameEventInstance
    {
        public List<GameEffect> GameEffects = new();
        private Dictionary<string, object> _baseParameters = new();
        private Dictionary<string, object> _parameters = new();
        private int _currentEffect;
        
        public void SetParameters(params (string name, object value)[] parameters)
        {
            foreach (var parameter in parameters)
            {
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
            @object = new T();
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
                gameEffect.Initialize();
            }
        }
        
        public void Update()
        {
            GameEffect effect = GameEffects[_currentEffect];
            
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
            if (_currentEffect >= GameEffects.Count)
            {
                GameEventsManager.KillEvent(this);
            }
        }
    }
}