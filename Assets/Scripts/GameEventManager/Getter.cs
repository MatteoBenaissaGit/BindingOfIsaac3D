using System;
using MBLib.GameEventManager.Effects;

namespace MBLib.GameEventManager
{
    [Serializable]
    public class Getter<T> where T : new()
    {
        public T TypeValue;
        public string Key;

        public T Value(GameEventInstance gameEvent)
        {
            if (string.IsNullOrEmpty(Key) == false)
            {
                if (gameEvent.GetParameter(Key, out T value))
                {
                    return value;
                }
            }
            return TypeValue;
        }
        
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Key) == false)
            {
                return $"{Key.Getter()}";
            }
            return TypeValue.ToString().Bold();
        }
    }
}