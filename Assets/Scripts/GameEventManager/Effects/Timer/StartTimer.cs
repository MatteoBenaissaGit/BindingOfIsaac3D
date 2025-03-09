using System;
using MBLib.GameEventManager.Attribute;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Timer/Start Timer"), GameEffectColor(EffectColors.TIMER)]
    public class StartTimer : GameEffect
    {
        public float Time;
        public string SaveKey;

        public override string ToString()
        {
            return $"Start Timer of {Time}s and save it as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            gameEvent.Timers.Add(SaveKey, Time);
            return true;
        }
    }
}