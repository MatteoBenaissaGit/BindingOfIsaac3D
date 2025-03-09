using System;
using Enemy;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("AI/Rotate toward"), GameEffectColor(EffectColors.AI)]
    public class RotateToward : GameEffect
    {
        public Getter<Vector3> Direction;

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(EnemyController.OWNER, out EnemyController enemy) == false)
            {
                return true;
            }
            
            enemy.transform.LookAt(enemy.transform.position + Direction.Value(gameEvent), Vector3.up);

            return true;
        }

        public override string ToString()
        {
            return $"{"[AI]".Bold()} Rotate toward {Direction}";
        }
    }
}