using System;
using Character;
using Data;
using DG.Tweening;
using UnityEngine;

namespace Projectiles
{
    public struct ProjectileMultipliers
    {
        public float SpeedMultiplier;
        public float RangeMultiplier;
        public float DamageMultiplier;
    }
    
    public struct ProjectileInfo
    {
        public float Speed;
        public float Range;
        public Vector3 Direction;
        public int Damage;
        public TeamType Team;
    }
    
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [field:SerializeField] public ProjectileData Data { get; private set; }
        
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ParticleSystem _destroyParticles;

        private ProjectileInfo _infos;
        private Vector3 _startPosition;
        private bool _isInitialized;

        public void Initialize(ProjectileMultipliers multipliers, Vector3 direction, TeamType team)
        {
            _infos = new ProjectileInfo()
            {
                Speed = Data.Speed * multipliers.SpeedMultiplier,
                Range = Data.Range * multipliers.RangeMultiplier,
                Damage = (int)(Data.Damage * multipliers.DamageMultiplier),
                Team = team,
                Direction = direction
            };
            
            _isInitialized = true;
            _startPosition = transform.position;
        }

        private void FixedUpdate()
        {
            if (_isInitialized == false) return;
            
            _rigidbody.velocity = _infos.Direction * _infos.Speed;
            
            if (Vector3.SqrMagnitude(transform.position - _startPosition) > _infos.Range)
            {
                Kill();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isInitialized == false) return;
            
            if (other.gameObject.TryGetComponent(out Projectile projectile) && projectile._infos.Team == _infos.Team)
            {
                return;
            }
            
            if (other.gameObject.TryGetComponent(out Character.GameEntity entity) == false)
            {
                Kill();
                return;
            }
            
            if (entity.Team == _infos.Team)
            {
                return;
            }
            
            entity.OnHit(_infos.Damage, IHittable.HitOrigin.Projectile);
            Kill();
        }

        private void Kill()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
            _isInitialized = false;
            
            transform.DOComplete();
            transform.DOScale(Vector3.zero, 0.2f).OnComplete(Destroy);
            
            if (_destroyParticles != null)
            {
                _destroyParticles.transform.parent = null;
                _destroyParticles.Play();
            }
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}