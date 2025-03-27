using System;
using DG.Tweening;
using Enemy;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    public enum AIFeedbackType
    {
        None = 0,
        PunchScale = 1
    }
    
    [Serializable, GameEffectName("AI/Feedback"), GameEffectColor(EffectColors.AI)]
    public class Feedback : GameEffect
    {
        public AIFeedbackType Type = AIFeedbackType.None;
        public float Force = 0.1f;
        public float Duration = 0.2f;
        
        public override string ToString()
        {
            return $"{"[AI]".Bold()} Feedback {Type.ToString().Bold()} with force {Force}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(EnemyController.OWNER, out EnemyController enemy) == false)
            {
                return true;
            }

            enemy.Mesh.DOComplete();
            switch(Type)
            {
                case AIFeedbackType.None:
                    break;
                case AIFeedbackType.PunchScale:
                    enemy.Mesh.DOPunchScale(Vector3.one * Force, Duration);
                    break;
            }

            return true;
        }
    }
}