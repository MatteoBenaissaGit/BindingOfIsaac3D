using System;
using Character;
using DG.Tweening;
using Projectiles;
using UnityEngine;

namespace DefaultNamespace
{
    public class Destructible : GameEntity
    {
        [SerializeField] private int _life = 3;
        [Space]
        [SerializeField] private bool _affectedByProjectiles = true;
        [SerializeField] private bool _projectilesHitDamageOne = true;
        [SerializeField] private bool _affectedByBombs = true;
        [Space]
        [SerializeField] private Gradient _colorGradient;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private ParticleSystem _destroyParticle;
        
        private int _currentLife;

        private void Awake()
        {
            _currentLife = _life;
            
            _meshRenderer.materials[0].color = _colorGradient.Evaluate(1);
        }

        protected override void OnHitInternal(float damage, IHittable.HitOrigin origin)
        {
            if (origin == IHittable.HitOrigin.Projectile)
            {
                if (_affectedByProjectiles == false)
                {
                    return;
                }
                
                damage = _projectilesHitDamageOne ? 1 : damage;
            }

            if (origin == IHittable.HitOrigin.Bomb)
            {
                if (_affectedByBombs == false)
                { 
                    return;
                }

                damage = _life;
            }

            AddDamage((int)damage);
        }

        private void AddDamage(int damage)
        {
            _currentLife -= damage;

            float scale = _currentLife / (float)_life;
            _meshRenderer.materials[0].color = _colorGradient.Evaluate(scale);

            transform.DOComplete();
            transform.DOPunchScale(Vector3.one * 0.2f, 0.3f).SetEase(Ease.InOutBack);
            
            if (_currentLife <= 0)
            {
                Destroy();
            }
        }

        private void Destroy()
        {
            if (_destroyParticle != null)
            {
                _destroyParticle.Play();
                _destroyParticle.transform.parent = null;
            }
            
            Destroy(gameObject);
        }
    }
}