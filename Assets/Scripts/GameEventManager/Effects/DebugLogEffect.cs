using System;
using System.Collections;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Common/Debug Log"), GameEffectColor(255, 255, 255)]
    public class DebugLogEffect : GameEffect
    {
        public string Text;

        public override string ToString()
        {
            return $"DebugLog : {Text}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            Debug.Log(Text);
            return true;
        }
    }
}