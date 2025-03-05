using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Gameplay/Get Direction To Position"), GameEffectColor(EffectColors.GAMEPLAY)]
    public class GetDirectionToEntity : GameEffect
    {
        public string Position;
        public string Destination;
        public string SaveKey;

        public override string ToString()
        {
            return $"Get direction from {Position.Getter()} to {(Destination).Getter()} and save it as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            
            if (gameEvent.GetParameter(Destination, out Vector3 destination) == false)
            {
                return true;
            }
            if (gameEvent.GetParameter(Position, out Vector3 position) == false)
            {
                return true;
            }
            

            Vector3 direction = destination - position;
            direction = direction.normalized;
            
            gameEvent.SetParameters((SaveKey, direction));
            return true;
        }
    }
}