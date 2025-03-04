using Data;
using DG.Tweening;
using Game;
using Gameplay;
using Projectiles;
using UnityEngine;

namespace Character
{
    public class ShootControllerGameplayData
    {
        public float ShootCooldown { get; set; } = 1.5f;
        public float BombShootForce { get; set; } = 1f;
        public float ShootCooldownMultiplier { get; set; } = 1;
        
        public float ProjectileSpeedMultiplier { get; set; } = 1;
        public float ProjectileRangeMultiplier { get; set; } = 1;
        public float ProjectileDamageMultiplier { get; set; } = 1;
        public float ProjectileDirectionRandomDegreesAmount { get; set; } = 10;
    }
    
    public class CharacterShootController : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Bomb _bombPrefab;
        [SerializeField] private Transform _shootPosition;
        [SerializeField] private Transform _mesh;
        
        public ShootControllerGameplayData GameplayData { get; private set; }

        private float ShootCooldown => GameplayData.ShootCooldown * GameplayData.ShootCooldownMultiplier;
        private float _currentShootCooldown;
        
        public void Initialize(CharacterData data)
        {
            GameplayData = new ShootControllerGameplayData();
            GameplayData.ShootCooldown = data.ShootCooldown;
            GameplayData.BombShootForce = data.BombShootForce;
            
            GameManager.Instance.Inputs.OnShootInput += OnShoot;
            GameManager.Instance.Inputs.OnBombShoot += DropBomb;
        }

        private void Update()
        {
            _currentShootCooldown -= Time.deltaTime;
        }

        private void OnShoot(Vector2Int direction)
        {
            if (_currentShootCooldown > 0) return;
            _currentShootCooldown = ShootCooldown;
            
            ShootProjectileInDirection(direction);

            _mesh.DOComplete();
            _mesh.DOPunchScale(Vector3.one * 0.2f, 0.2f);
            
            GameManager.Instance.Character.TopDown.ForceFacingForSeconds(ShootCooldown, direction);
        }
        
        private void ShootProjectileInDirection(Vector2 direction)
        {
            direction = direction.normalized;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float randomAmount = GameplayData.ProjectileDirectionRandomDegreesAmount;
            angle += Random.Range(-randomAmount, randomAmount);
            Vector2 flatDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            
            Vector3 projectileDirection = new Vector3(flatDirection.x, 0, flatDirection.y);
            
            Projectile projectile = Instantiate(_projectilePrefab, _shootPosition.position, Quaternion.identity);
            ProjectileMultipliers multipliers = new ProjectileMultipliers()
            {
                SpeedMultiplier = GameplayData.ProjectileSpeedMultiplier,
                RangeMultiplier = GameplayData.ProjectileRangeMultiplier,
                DamageMultiplier = GameplayData.ProjectileDamageMultiplier
            };
            projectile.Initialize(multipliers, projectileDirection, TeamType.Player);
        }

        private void DropBomb()
        {
            Vector3 direction = GameManager.Instance.Character.transform.forward;
            Vector3 position = _shootPosition.position + _shootPosition.forward * 1.5f;
            
            Bomb bomb = Instantiate(_bombPrefab, position, Quaternion.identity);
            bomb.Rigidbody.AddForce(new Vector3(direction.x, 0, direction.z) * GameplayData.BombShootForce, ForceMode.Impulse);
            bomb.SpawnAnimation();
        }
    }
}