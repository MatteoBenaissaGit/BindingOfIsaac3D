using System;
using System.Collections;

namespace MBLib.GameEventManager.Effects
{
    [Serializable]
    public class GameEffect
    {
        public bool Enabled = true;

        public virtual void Initialize(GameEventInstance gameEvent)
        {
            
        }
        
        public override string ToString()
        {
            return string.Empty;
        }

        public virtual bool Execute(GameEventInstance gameEvent)
        {
            return true;
        }
    }
    
    public static class StringExtensions
    {
        public static string Bold(this string str)
        {
            return $"<b>{str}</b>";
        }
        
        public static string Getter(this string str)
        {
            return $"<color=yellow><b>'{str}'</b></color>";
        }
        
        public static string Setter(this string str)
        {
            return $"<color=orange><b>'{str}'</b></color>";
        }
    }
}