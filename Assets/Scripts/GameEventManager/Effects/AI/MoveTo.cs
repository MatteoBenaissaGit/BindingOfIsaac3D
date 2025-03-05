using System;
using Enemy;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("AI/Move to"), GameEffectColor(0, 255, 255)]
    public class MoveTo : GameEffect
    {
        public string Position;
        public float Time;

        public override string ToString()
        {
            return $"{"[AI]".Bold()} Move to {Position.Getter()} in {(Time + "s").Bold()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(EnemyController.OWNER, out EnemyController enemy) == false)
            {
                return true;
            }
            if (gameEvent.GetParameter(Position, out Vector3 position) == false)
            {
                return true;
            }
            
            enemy.MoveTo(position, Time);
            
            return true;
        }
    }
}