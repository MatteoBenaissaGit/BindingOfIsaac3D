using System;
using Common;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Math/Get Vector3 Direction From Angle"), GameEffectColor(EffectColors.VECTOR3)]
    public class GetDirectionFromAngle : GameEffect
    {
        public string Angle;
        public string DirectionSaveKey;

        public override string ToString()
        {
            return $"Get direction from {Angle.Getter()} and save it as {DirectionSaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(Angle, out float angle) == false)
            {
                return true;
            }

            Vector3 direction = angle.AsDirection();
            gameEvent.SetParameters((DirectionSaveKey, direction));
            return true;
        }
    }
}