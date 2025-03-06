using System;
using Enemy;
using MBLib.GameEventManager.Attribute;
using UnityEngine;
using UnityEngine.Serialization;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("AI/Set Velocity"), GameEffectColor(EffectColors.AI)]
    public class SetVelocity : GameEffect
    {
        public Getter<Vector3> Direction;
        public Getter<float> Magnitude;

        public override string ToString()
        {
            return $"{"[AI]".Bold()} Set velocity to {Direction} * {Magnitude}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(EnemyController.OWNER, out EnemyController enemy) == false)
            {
                return true;
            }
            
            enemy.GetComponent<Rigidbody>().velocity = Direction.Value(gameEvent) * Magnitude.Value(gameEvent);
            
            return true;
        }
    }
}