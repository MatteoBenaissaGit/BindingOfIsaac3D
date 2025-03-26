using System;
using System.Collections;
using Enemy;
using Game;
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
            if (gameEvent.GetParameter(PositionKey, out Vector3 position) == false)
            {
                return true;
            }
            
            GameObject objectInstance = Object.Instantiate(Prefab, position + Offset, Quaternion.identity);
            
            if (objectInstance.gameObject.TryGetComponent(out EnemyController enemy))
            {
                GameManager.Instance.RoomController.AddEnemyToRoom(enemy);
                enemy.StartBehavior();
            }
            
            return true;
        }
        
    }
}