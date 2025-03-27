using UnityEngine;

namespace Enemy
{
    public interface IAi
    {
        public void HitDamage(int damage);
        public void Die(bool silent = false);
        public void MoveTo(Vector3 position, float duration);
        public void AddForceInDirection(Vector3 direction, float force);
    }
}