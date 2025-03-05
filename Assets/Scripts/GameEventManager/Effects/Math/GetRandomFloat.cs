using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Math/Get Random Float"), GameEffectColor(EffectColors.FLOAT)]
    public class GetRandomFloat : GameEffect
    {
        public Vector2 Range;
        public string SaveKey;

        public override string ToString()
        {
            return $"Get random between {Range.x.ToString().Bold()} and {Range.y.ToString().Bold()} and save it as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            float random = UnityEngine.Random.Range(Range.x, Range.y);
            
            gameEvent.SetParameters((SaveKey, random));
            return true;
        }
    }
}