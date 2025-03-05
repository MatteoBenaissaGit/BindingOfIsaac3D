using System;
using System.Collections;
using MBLib.GameEventManager.Attribute;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Gameplay/Instantiate"), GameEffectColor(EffectColors.GAMEPLAY)]
    public class InstantiateEffect : GameEffect
    {
        public GameObject Prefab;
        public string PositionKey;
        public Vector3 Offset;

        public override string ToString()
        {
            return $"Instantiate {(Prefab != null ? Prefab.name : "nothing")} at {PositionKey.Getter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter<Vector3>(PositionKey, out Vector3 position) == false)
            {
                return true;
            }
            
            Object.Instantiate(Prefab, position + Offset, Quaternion.identity);
            return true;
        }
        
    }
}