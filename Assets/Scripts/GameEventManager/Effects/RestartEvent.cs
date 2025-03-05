using System;
using MBLib.GameEventManager.Attribute;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Common/Restart Event"), GameEffectColor(EffectColors.COMMON)]
    public class RestartEvent : GameEffect
    {
        
        public override string ToString()
        {
            return $"Restart event".Bold();
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            return true;
        }
    }
}