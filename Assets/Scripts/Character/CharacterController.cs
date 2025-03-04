using Data;
using DG.Tweening;
using Game;
using Projectiles;
using UnityEngine;

namespace Character
{
    public class CharacterGameplayData
    {
        public CharacterGameplayData()
        {
            Life = 6;
            MaxLife = 6;
        }
        
        public int Life { get; set; }
        public int MaxLife { get; set; }
    }
    
    public class CharacterController : GameEntity
    {
        [field:SerializeField] public TopDown3DController TopDown { get; private set; }
        [field:SerializeField] public CharacterShootController Shoot { get; private set; }
        [field:SerializeField] public CharacterData Data { get; private set; }
        [field:SerializeField] public Animator Animator { get; private set; }
        [field:SerializeField] public SkinnedMeshRenderer SkinnedMesh { get; private set; }
        
        public CharacterGameplayData GameplayData { get; private set; }
        
        private static readonly int DeathTriggerAnimator = Animator.StringToHash("Death");

        private void Start()
        {
            GameplayData = new CharacterGameplayData();

            Shoot.Initialize(Data, this);
            TopDown.Initialize(Data, this);
            
            GameManager.Instance.UI.Life.Initialize(GameplayData.Life, GameplayData.MaxLife);
        }
        
        protected override void OnHitInternal(float damage, IHittable.HitOrigin origin)
        {
            GameplayData.Life -= (int)damage;
            
            GameManager.Instance.UI.Life.UpdateLife(GameplayData.Life);

            foreach (Material material in SkinnedMesh.materials)
            {
                material.DOComplete();
                material.DOColor(Color.red, 0.1f).OnComplete(() =>
                {
                    material.DOColor(Color.white, 0.1f);
                });
            }
            
            if (GameplayData.Life <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Animator.SetTrigger(DeathTriggerAnimator);
            
            TopDown.Disable();
            Shoot.Disable();
        }
    }
}