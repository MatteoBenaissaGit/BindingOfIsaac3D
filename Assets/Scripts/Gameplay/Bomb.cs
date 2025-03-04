using System;
using Character;
using Projectiles;
using UnityEngine;

namespace Gameplay
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _explosionTime = 3;
        [SerializeField] private float _explosionRadius = 2;
        [SerializeField] private ParticleSystem _explosionParticle;
        
        private float _timer;

        private void Start()
        {
            _timer = _explosionTime;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                Explode();
            }
        }

        private void Explode()
        {
            RaycastHit[] hits = new RaycastHit[32];
            int hitCount = Physics.SphereCastNonAlloc(transform.position, _explosionRadius, Vector3.up, hits);
            for (int i = 0; i < hitCount; i++)
            {
                if (hits[i].collider.TryGetComponent(out GameEntity entity))
                {
                    entity.OnHit(10, IHittable.HitOrigin.Bomb);
                }
            }
            
            _explosionParticle.Play();
            _explosionParticle.transform.parent = null;
            
            Destroy(gameObject);
        }
        
#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }

#endif
    }
}