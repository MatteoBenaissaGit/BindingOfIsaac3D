using Projectiles;
using UnityEngine;

namespace Character
{
    public enum TeamType
    {
        Neutral = 0,
        Player = 1,
        Enemy = 2
    }
    
    public abstract class GameEntity : MonoBehaviour, IHittable
    {
        [field:SerializeField] public TeamType Team { get; private set; }
        
        public void OnHit(float damage, IHittable.HitOrigin origin)
        {
            OnHitInternal(damage, origin);
        }

        protected abstract void OnHitInternal(float damage, IHittable.HitOrigin origin);
    }
}