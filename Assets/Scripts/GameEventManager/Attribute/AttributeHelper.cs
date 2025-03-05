using System;
using System.Linq;

namespace MBLib.GameEventManager.Attribute
{
    public static class AttributeHelper
    {
        public static GameEffectColor GetGameEffectColorAttribute(Type type)
        {
            return (GameEffectColor)type.GetCustomAttributes(typeof(GameEffectColor), false).FirstOrDefault();
        }
    }
}