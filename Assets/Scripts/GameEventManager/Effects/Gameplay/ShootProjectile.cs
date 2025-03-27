using System;
using Character;
using MBLib.GameEventManager.Attribute;
using Projectiles;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MBLib.GameEventManager.Effects
{
    [Serializable, GameEffectName("Gameplay/Shoot Projectile"), GameEffectColor(EffectColors.GAMEPLAY)]
    public class ShootProjectile : GameEffect
    {
        public string Position;
        public GameObject Projectile;
        public Getter<Vector3> Direction;
        public TeamType Team;

        public override string ToString()
        {
            return $"Shoot projectile {(Projectile == null ? "null" : Projectile.name).Bold()} from {Position} in direction {Direction}";
        }

        public override bool Execute(GameEventInstance gameEvent)
        {
            if (gameEvent.GetParameter(Position, out Vector3 position) == false)
            {
                return true;
            }
            
            Projectile projectile = Object.Instantiate(Projectile, position, Quaternion.identity).GetComponent<Projectile>();
            ProjectileMultipliers multipliers = new ProjectileMultipliers()
            {
                DamageMultiplier = 1, RangeMultiplier = 1, SpeedMultiplier = 1
            };
            projectile.Initialize(multipliers, Direction.Value(gameEvent), Team);
            
            return true;
        }
    }
}