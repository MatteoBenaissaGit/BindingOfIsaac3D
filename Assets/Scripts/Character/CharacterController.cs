using Data;
using DG.Tweening;
using Game;
using Projectiles;
using UI;
using UnityEngine;

namespace Character
{
    public class CharacterGameplayData
    {
        public CharacterGameplayData()
        {
            Life = 6;
            MaxLife = 6;
            Bomb = 3;
            Money = 0;
        }
        
        public int Life { get; set; }
        public int MaxLife { get; set; }
        public int Bomb { get; set; }
        public int Money { get; set; }
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
            
            UIManager ui = GameManager.Instance.UI;
            ui.Life.Initialize(GameplayData.Life, GameplayData.MaxLife);
            ui.Stats.Set(UIStats.StatType.Bomb, GameplayData.Bomb);
            ui.Stats.Set(UIStats.StatType.Money, GameplayData.Money);
        }
        
        protected override void OnHitInternal(float damage, IHittable.HitOrigin origin)
        {
            if (GameplayData.Life <= 0) return;
            
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
            foreach (Material material in SkinnedMesh.materials)
            {
                material.DOComplete();
                material.DOColor(new Color(0.29f, 0.29f, 0.29f), 1f);
            }
            
            Animator.SetTrigger(DeathTriggerAnimator);
            
            TopDown.Disable();
            Shoot.Disable();
        }
    }
}