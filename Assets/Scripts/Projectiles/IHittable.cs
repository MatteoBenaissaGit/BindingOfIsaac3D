namespace Projectiles
{
    public interface IHittable
    {
        public enum HitOrigin
        {
            Contact = 0,
            Projectile = 1,
            Bomb = 2
        }
        
        public void OnHit(float damage, HitOrigin origin);
    }
}