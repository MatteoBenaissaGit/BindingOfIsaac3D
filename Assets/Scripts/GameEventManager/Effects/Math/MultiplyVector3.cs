using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Math/Multiply Vector3"), GameEffectColor(255, 0, 127)]
    public class MultiplyVector3 : GameEffect
    {
        public string Vector;
        public float MultiplyAmount;
        public string SaveKey;

        public override string ToString()
        {
            return $"Multiply {Vector.Getter()} by {MultiplyAmount.ToString().Bold()} and save it as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(Vector, out Vector3 vector) == false)
            {
                return true;
            }
            Vector3 multipliedVector = vector * MultiplyAmount;
            
            gameEvent.SetParameters((SaveKey, multipliedVector));
            return true;
        }
    }
}