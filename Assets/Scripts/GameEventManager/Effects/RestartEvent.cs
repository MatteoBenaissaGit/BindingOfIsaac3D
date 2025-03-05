using System;
using MBLib.GameEventManager.Attribute;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Common/Restart Event"), GameEffectColor(255, 255, 0)]
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