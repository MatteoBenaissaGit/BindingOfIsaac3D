using System;
using MBLib.GameEventManager.Attribute;

namespace MBLib.GameEventManager.Effects.Conditions
{
    [Serializable, GameEffectName("Condition/If"), GameEffectColor(EffectColors.CONDITION)]
    public class If : ConditionalGameEffect
    {
        public override string ToString()
        {
            return $"If {ConditionToString()}".Bold();
        }
    }
}