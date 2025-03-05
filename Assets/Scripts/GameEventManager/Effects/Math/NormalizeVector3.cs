using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Math/Normalize Vector3"), GameEffectColor(EffectColors.VECTOR3)]
    public class NormalizeVector3 : GameEffect
    {
        public string Vector;
        public string SaveKey;

        public override string ToString()
        {
            return $"Normalize {Vector.Getter()} and save it as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(Vector, out Vector3 vectorA) == false)
            {
                return true;
            }
            Vector3 normalizedVector = vectorA.normalized;
            
            gameEvent.SetParameters((SaveKey, normalizedVector));
            return true;
        }
    }
}