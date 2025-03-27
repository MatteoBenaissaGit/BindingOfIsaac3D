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
            
            AddLife(-(int)damage);

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

        public void AddLife(int value)
        {
            GameplayData.Life += value;
            if (GameplayData.Life > GameplayData.MaxLife)
            {
                GameplayData.Life = GameplayData.MaxLife;
            }
            else if (GameplayData.Life < 0)
            {
                GameplayData.Life = 0;
            }
            
            GameManager.Instance.UI.Life.UpdateLife(GameplayData.Life);
        }

        public void AddBomb(int value)
        {
            GameplayData.Bomb += value;
            if (GameplayData.Bomb < 0)
            {
                GameplayData.Bomb = 0;
            }
            
            GameManager.Instance.UI.Stats.Set(UIStats.StatType.Bomb, GameplayData.Bomb);
        }

        public void AddMoney(int value)
        {
            GameplayData.Money += value;
            if (GameplayData.Money < 0)
            {
                GameplayData.Money = 0;
            }
            
            GameManager.Instance.UI.Stats.Set(UIStats.StatType.Money, GameplayData.Money);
        }
        
        private void Die()
        {
            foreach (Material material in SkinnedMesh.materials)
            {
                material.DOComplete();
                material.DOColor(new Color(0.29f, 0.29f, 0.29f), 1f);
            }
            
            Animator.SetTrigger(DeathTriggerAnimator);
            
            Disable();
        }

        public void Enable()
        {
            TopDown.Enable();
            Shoot.Enable();
        }
        
        public void Disable()
        {
            TopDown.Disable();
            Shoot.Disable();
        }
    }
}