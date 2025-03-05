using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Common/Wait"), GameEffectColor(255, 255, 0)]
    public class WaitEffect : GameEffect
    {
        public float Timer;

        private float _timer;

        public override void Initialize()
        {
            _timer = Timer;
        }

        public override string ToString()
        {
            return $"Wait {Timer}s";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            _timer -= Time.deltaTime;
            if (_timer > 0) return false;
            return true;
        }
    }
}