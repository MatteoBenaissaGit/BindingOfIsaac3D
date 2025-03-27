using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Math/Rotate Direction"), GameEffectColor(EffectColors.VECTOR3)]
    public class RotateDirection : GameEffect
    {
        public Getter<Vector3> Direction;
        public Getter<float> AmountToRotateInDegrees;
        public string SaveKey;

        public override string ToString()
        {
            return $"Rotate {Direction} to {AmountToRotateInDegrees} and save it as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            Vector3 vectorToRotate = Direction.Value(gameEvent);
            Vector3 addVector = Quaternion.Euler(0, AmountToRotateInDegrees.Value(gameEvent), 0) * vectorToRotate;
            
            gameEvent.SetParameters((SaveKey, addVector));
            return true;
        }
    }
}