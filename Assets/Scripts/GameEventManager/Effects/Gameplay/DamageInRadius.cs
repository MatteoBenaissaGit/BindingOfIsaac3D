using System;
using Character;
using MBLib.GameEventManager.Attribute;
using Projectiles;
using UnityEngine;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Gameplay/Do Damage In Radius"), GameEffectColor(EffectColors.GAMEPLAY)]
    public class DamageInRadius : GameEffect
    {
        public string Position;
        public Getter<float> Radius;
        public Getter<int> Damage;
        public TeamType Team;
        public IHittable.HitOrigin Origin;

        public override string ToString()
        {
            return $"Do {Damage} damage in radius {Radius} from {Position.Getter()}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(Position, out Vector3 position) == false)
            {
                return true;
            }
            
            RaycastHit[] hits = new RaycastHit[32];
            int hitCount = Physics.SphereCastNonAlloc(position, Radius.Value(gameEvent), Vector3.up, hits);
            for (int i = 0; i < hitCount; i++)
            {
                if (hits[i].collider.TryGetComponent(out GameEntity entity) && entity.Team != Team)
                {
                    entity.OnHit(Damage.Value(gameEvent), Origin);
                }
            }
            
            return true;
        }
    }
}