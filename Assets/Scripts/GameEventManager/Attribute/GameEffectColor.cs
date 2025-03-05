using System;

namespace MBLib.GameEventManager.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GameEffectColor : System.Attribute
    {
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }

        public GameEffectColor(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public override string ToString()
        {
            return $"RGB({Red}, {Green}, {Blue})";
        }
    }
}