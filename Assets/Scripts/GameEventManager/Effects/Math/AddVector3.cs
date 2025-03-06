using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Math/Add Vector3"), GameEffectColor(EffectColors.VECTOR3)]
    public class AddVector3 : GameEffect
    {
        public Getter<Vector3> VectorA;
        public Getter<Vector3> VectorB;
        public string SaveKey;

        public override string ToString()
        {
            return $"Add {VectorA} and {VectorB} and save it as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            Vector3 addVector = VectorA.Value(gameEvent) + VectorB.Value(gameEvent);
            
            gameEvent.SetParameters((SaveKey, addVector));
            return true;
        }
    }
}