using System;
using Enemy;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("AI/Add force to direction"), GameEffectColor(EffectColors.AI)]
    public class AddForceToDirection : GameEffect
    {
        public string Direction;
        public Getter<float> Force;

        public override string ToString()
        {
            return $"{"[AI]".Bold()} Add force toward {Direction.Getter()} with {Force}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(EnemyController.OWNER, out EnemyController enemy) == false)
            {
                return true;
            }
            if (gameEvent.GetParameter(Direction, out Vector3 direction) == false)
            {
                return true;
            }
            
            enemy.AddForceInDirection(direction, Force.Value(gameEvent));
            
            return true;
        }
    }
}