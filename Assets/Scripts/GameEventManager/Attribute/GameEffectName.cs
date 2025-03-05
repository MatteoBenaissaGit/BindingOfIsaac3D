using System;

namespace MBLib.GameEventManager.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GameEffectName : System.Attribute
    {
        public string Name { get; }

        public GameEffectName(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}