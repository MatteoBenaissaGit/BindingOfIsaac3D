using System;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

namespace MBLib.GameEventManager.Attribute
{
    public static class EffectColors
    {
        public const KnownColor VECTOR3 = KnownColor.Crimson; 
        public const KnownColor FLOAT = KnownColor.Olive;
        public const KnownColor GAMEPLAY = KnownColor.Orange;
        public const KnownColor AI = KnownColor.DodgerBlue;
        public const KnownColor COMMON = KnownColor.Gold;
        public const KnownColor AUDIO = KnownColor.Bisque;
        public const KnownColor TIMER = KnownColor.Chartreuse;
        public const KnownColor CONDITION = KnownColor.Red;
    }
    
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
        
        public GameEffectColor(KnownColor color)
        {
            System.Drawing.Color drawingColor = System.Drawing.Color.FromKnownColor(color);
            Red = drawingColor.R;
            Green = drawingColor.G;
            Blue = drawingColor.B;
        }

        public override string ToString()
        {
            return $"RGB({Red}, {Green}, {Blue})";
        }
    }
}