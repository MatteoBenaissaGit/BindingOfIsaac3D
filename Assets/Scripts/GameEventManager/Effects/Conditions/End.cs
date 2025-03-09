using System;
using MBLib.GameEventManager.Attribute;

namespace MBLib.GameEventManager.Effects.Conditions
{
    [Serializable, GameEffectName("Condition/End Condition Block"), GameEffectColor(EffectColors.CONDITION)]
    public class End : GameEffect
    {
        public override string ToString()
        {
            return "End condition block".Bold();
        }
    }
}