using System;
using Character;
using Data;
using DG.Tweening;
using Game;
using Gameplay;
using MBLib.GameEventManager;
using Projectiles;
using UnityEngine;

namespace Enemy
{
    public class EnemyGameplayData
    {
        public EnemyGameplayData(int life)
        {
            Life = life;
        }
        
        public int Life { get; set; }
    }
    
    public class EnemyController : GameEntity, IAi
    {
        [SerializeField] private EnemyData _data;
        [SerializeField] private GameEvent _behavior;
        [SerializeField] private Rigidbody _rigidbody;
        [Space, SerializeField] private SkinnedMeshRenderer _skinnedMesh;
        [SerializeField] private MeshRenderer _mesh;
        [SerializeField] private ParticleSystem _deathParticle;

        public EnemyGameplayData GameplayData { get; private set; }
        public Action<EnemyController> OnDie { get; set; }
        public Action<float> OnHit { get; set; }
        
        public static string OWNER = "Owner";

        private Guid _behaviorGuid;
        
        public void StartBehavior()
        {
            GameplayData = new(_data.Life);
            _behaviorGuid = GameEventsManager.PlayEvent(_behavior, (OWNER, this));
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_data.DamagePlayerOnContact == false) return;
            
            if (collision.gameObject.TryGetComponent(out GameEntity entity) && entity.Team != Team)
            {
                entity.OnHit(_data.ContactDamage, IHittable.HitOrigin.Contact);
            }
        }

        protected override void OnHitInternal(float damage, IHittable.HitOrigin origin)
        {
            HitDamage((int)damage);
        }

        public void HitDamage(int damage)
        {
            Material[] materials = _mesh == null ? _skinnedMesh == null ? null : _skinnedMesh.materials : _mesh.materials;
            if (materials != null)
            {
                foreach (Material material in materials)
                {
                    material.DOComplete();
                    material.DOColor(Color.red, 0.1f).OnComplete(() =>
                    {
                        material.DOColor(Color.white, 0.1f);
                    });
                }
            }
            
            GameplayData.Life -= damage;
            OnHit?.Invoke((float)GameplayData.Life / _data.Life);

            if (GameplayData.Life <= 0)
            {
                Die();
            }
        }

        public void Die(bool silent = false)
        {
            if (_deathParticle != null)
            {
                _deathParticle.Play();
                _deathParticle.transform.parent = null;
            }
            
            //drop
            if (_data.Drop.GetDrop(out ItemType type, out int amount))
            {
                GameManager.Instance.RoomController.SpawnPickableItem(transform.position, type, amount);
            }
            
            //destroy
            GameEventsManager.KillEvent(_behaviorGuid);
            if (silent == false)
            {
                OnDie?.Invoke(this);
            }
            Destroy(gameObject);
        }

        public void MoveTo(Vector3 position, float force)
        {
            transform.DOKill();
            transform.DOMove(position, force);
        }

        public void AddForceInDirection(Vector3 direction, float force)
        {
            _rigidbody.AddForce(direction * force, ForceMode.Impulse);
        }

#if UNITY_EDITOR

        private GameEvent _lastBehavior;
        private void OnValidate()
        {
            string parameter = $"{OWNER} <EnemyController>";
            if (_behavior == null && _lastBehavior != null)
            {
                _lastBehavior.ParametersKnown.Remove(OWNER);
            }
            if (_lastBehavior != null && _behavior != _lastBehavior)
            {
                _lastBehavior = _behavior;
            }
            if (_behavior != null && _behavior.ParametersKnown.Contains(parameter) == false)
            {
                _behavior.ParametersKnown.Add(parameter);
            }
        }

#endif
    }
}