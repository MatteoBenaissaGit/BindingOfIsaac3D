using System;
using Game;
using MBLib.GameEventManager.Attribute;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Common/Shake Camera"), GameEffectColor(EffectColors.COMMON)]
    public class ShakeCamera : GameEffect
    {
        public Getter<float> Duration;
        
        public override string ToString()
        {
            return $"Shake Camera for {Duration}s";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            GameManager.Instance.CameraController.Shake(Duration.Value(gameEvent));
            
            return true;
        }
    }
}