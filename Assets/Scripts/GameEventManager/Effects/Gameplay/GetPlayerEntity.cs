using System;
using Game;
using MBLib.GameEventManager.Attribute;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Gameplay/Get Player Entity"), GameEffectColor(EffectColors.GAMEPLAY)]
    public class GetPlayerEntity : GameEffect
    {
        public string SaveKey;

        public override string ToString()
        {
            return $"Save {("Player").Bold()} as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            gameEvent.SetParameters((SaveKey, GameManager.Instance.Character));
            return true;
        }
    }
}