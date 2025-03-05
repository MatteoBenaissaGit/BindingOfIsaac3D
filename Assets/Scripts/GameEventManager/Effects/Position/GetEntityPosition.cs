using System;
using MBLib.GameEventManager.Attribute;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Position/Get EntityPosition"), GameEffectColor(255, 128, 0)]
    public class GetEntityPosition : GameEffect
    {
        public string EntityKey;
        public string SaveKey;

        public override string ToString()
        {
            return $"Save {EntityKey.Getter()}'s position as {SaveKey.Setter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(EntityKey, out MonoBehaviour entity) == false)
            {
                return true;
            }
            
            gameEvent.SetParameters((SaveKey, entity.transform.position));
            return true;
        }
    }
}