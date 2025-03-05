using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Math/Set Vector3"), GameEffectColor(255, 0, 127)]
    public class SetVector3 : GameEffect
    {
        public Vector3 Vector;
        public string SaveKey;

        public override string ToString()
        {
            return $"Save {Vector.ToString().Bold()} as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            gameEvent.SetParameters((SaveKey, Vector));
            return true;
        }
    }
}