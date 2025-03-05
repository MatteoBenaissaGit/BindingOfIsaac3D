using System;
using Character;
using Data;
using DG.Tweening;
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
        [SerializeField] private int _life = 3;
        [Space, SerializeField] private SkinnedMeshRenderer _skinnedMesh;

        public EnemyGameplayData GameplayData { get; private set; }
        
        public static string OWNER = "Owner";

        private Guid _behaviorGuid;
        
        private void Start()
        {
            GameplayData = new(_life);
            
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
            if (_skinnedMesh != null)
            {
                foreach (Material material in _skinnedMesh.materials)
                {
                    material.DOComplete();
                    material.DOColor(Color.red, 0.1f).OnComplete(() =>
                    {
                        material.DOColor(Color.white, 0.1f);
                    });
                }
            }
            
            GameplayData.Life -= damage;

            if (GameplayData.Life <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            GameEventsManager.KillEvent(_behaviorGuid);
            
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