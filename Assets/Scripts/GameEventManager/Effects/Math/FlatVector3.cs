using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Math/Flat Vector3"), GameEffectColor(EffectColors.VECTOR3)]
    public class FlatVector3 : GameEffect
    {
        public string Vector;
        public string SaveKey;

        public override string ToString()
        {
            return $"Flat (remove y) {Vector.Getter()} and save it as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(Vector, out Vector3 vector) == false)
            {
                return true;
            }
            Vector3 flatVector = new Vector3(vector.x,0,vector.z);
            
            gameEvent.SetParameters((SaveKey, flatVector));
            return true;
        }
    }
}