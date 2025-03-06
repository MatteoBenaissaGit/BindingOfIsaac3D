using System;
using Enemy;
using MBLib.GameEventManager.Attribute;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("AI/Die"), GameEffectColor(EffectColors.AI)]
    public class Die : GameEffect
    {
        public override string ToString()
        {
            return $"{"[AI]".Bold()} Die";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(EnemyController.OWNER, out EnemyController enemy) == false)
            {
                return true;
            }
            
            enemy.Die();
            
            return true;
        }
    }
}