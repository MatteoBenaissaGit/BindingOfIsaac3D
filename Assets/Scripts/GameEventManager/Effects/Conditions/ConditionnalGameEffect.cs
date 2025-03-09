using System;

namespace MBLib.GameEventManager.Effects.Conditions
{
    public enum Condition
    {
        None = 0,
        Timer = 1
    }

    public abstract class ConditionalGameEffect : GameEffect
    {
        public Condition Condition;
        public string Key;

        public bool IsTrue(GameEventInstance instance)
        {
            switch (Condition)
            {
                case Condition.None:
                    return true;
                case Condition.Timer:
                    if (instance.Timers.TryGetValue(Key, out float time))
                        return time > 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return true;
        }

        public string ConditionToString()
        {
            switch (Condition)
            {
                case Condition.None:
                    return "nothing";
                case Condition.Timer:
                    return $"{Key.Getter()} timer is > 0";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}