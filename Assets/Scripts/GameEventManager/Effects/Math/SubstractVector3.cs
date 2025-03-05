using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Math/Substract Vector3"), GameEffectColor(EffectColors.VECTOR3)]
    public class SubstractVector3 : GameEffect
    {
        public string VectorA;
        public string VectorB;
        public string SaveKey;

        public override string ToString()
        {
            return $"Substract {VectorA.Getter()} by {VectorB.Getter()} and save it as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(VectorA, out Vector3 vectorA) == false)
            {
                return true;
            }
            if (gameEvent.GetParameter(VectorB, out Vector3 vectorB) == false)
            {
                return true;
            }
            Vector3 addVector = vectorA - vectorB;
            
            gameEvent.SetParameters((SaveKey, addVector));
            return true;
        }
    }
}