using System;
using MBLib.GameEventManager.Attribute;

namespace MBLib.GameEventManager.Effects.Conditions
{
    [Serializable, GameEffectName("Condition/While"), GameEffectColor(EffectColors.CONDITION)]
    public class While : ConditionalGameEffect
    {
        public override string ToString()
        {
            return $"While {ConditionToString()}".Bold();
        }
    }
}