using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Common/Wait"), GameEffectColor(EffectColors.COMMON)]
    public class WaitEffect : GameEffect
    {
        public Getter<float> Timer;

        private float _timer;
        private bool _isInitialized;

        public override void Initialize(GameEventInstance gameEvent)
        {
            _isInitialized = false;
        }

        public override string ToString()
        {
            return $"Wait {Timer}s";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (_isInitialized == false)
            {
                _timer = Timer.Value(gameEvent);
                _isInitialized = true;
            }
            
            _timer -= Time.deltaTime;
            if (_timer > 0) return false;
            return true;
        }
    }
}