using Data;
using Projectiles;
using UnityEngine;

namespace Character
{
    public class CharacterGameplayData
    {
        public CharacterGameplayData()
        {
            Life = 6;
        }
        
        public int Life { get; set; }
    }
    
    public class CharacterController : GameEntity
    {
        [field:SerializeField] public TopDown3DController TopDown { get; private set; }
        [field:SerializeField] public CharacterShootController Shoot { get; private set; }
        [field:SerializeField] public CharacterData Data { get; private set; }
       
        public CharacterGameplayData GameplayData { get; private set; }
        
        private void Start()
        {
            GameplayData = new CharacterGameplayData();

            Shoot.Initialize(Data);
            TopDown.Initialize(Data);
        }
        
        protected override void OnHitInternal(float damage, IHittable.HitOrigin origin)
        {
            GameplayData.Life -= (int)damage;
        }
    }
}