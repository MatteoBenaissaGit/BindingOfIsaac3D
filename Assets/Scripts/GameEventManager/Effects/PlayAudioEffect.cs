using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Audio/Play Audio"), GameEffectColor(EffectColors.AUDIO)]
    public class PlayAudioEffect : GameEffect
    {
        public AudioClip Clip;
        [Range(0,1)] public float Volume;

        public override string ToString()
        {
            return $"Play {(Clip != null ? Clip.name : "nothing")}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            AudioSource.PlayClipAtPoint(Clip, Camera.main.transform.position);
            
            return true;
        }
    }
}