using System;
using Gameplay;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class DropChance
    {
        [Range(0,1)] public float DropRate = 0.25f;
        [Space]
        [Range(0,1)] public float HealthDropChance = 0.3f;
        [Range(0,1)] public float BombDropChance = 0.3f;
        [Range(0,1)] public float MoneyDropChance = 0.3f;
        [Space]
        [Range(0,10)] public int HealthDropAmount = 1;
        [Range(0,10)] public int BombDropAmount = 1;
        [Range(0,10)] public int MoneyDropAmount = 5;

        public bool GetDrop(out ItemType type, out int amount)
        {
            type = ItemType.None;
            amount = 0;
         
            float dropRateChanceRandom = UnityEngine.Random.Range(0f, 1f);
            if (dropRateChanceRandom > DropRate) return false;
            
            float dropTypeRandom = UnityEngine.Random.Range(0f, 1f);
            if (dropTypeRandom < HealthDropChance)
            {
                type = ItemType.Life;
                amount = HealthDropAmount;
            }
            else if (dropTypeRandom < HealthDropChance + BombDropChance)
            {
                type = ItemType.Bomb;
                amount = BombDropAmount;
            }
            else if (dropTypeRandom < HealthDropChance + BombDropChance + MoneyDropChance)
            {
                type = ItemType.Money;
                amount = MoneyDropAmount;
            }

            return true;
        }
        
#if UNITY_EDITOR

        public void Validate()
        {
            Vector3 dropRateVector = new(HealthDropChance, BombDropChance, MoneyDropChance);
            float sum = dropRateVector.x + dropRateVector.y + dropRateVector.z;
        
            if (sum != 0)
            {
                dropRateVector.x /= sum;
                dropRateVector.y /= sum;
                dropRateVector.z /= sum;
            }
            
            HealthDropChance = dropRateVector.x;
            BombDropChance = dropRateVector.y;
            MoneyDropChance = dropRateVector.z;
        }
        
#endif
    }
     
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public int Life { get; private set; } = 3;
        [field: SerializeField] public bool DamagePlayerOnContact { get; private set; } = true;
        [field: SerializeField] public int ContactDamage { get; private set; } = 1;
        [field: SerializeField] public DropChance Drop { get; private set; } = new() ;

        
#if UNITY_EDITOR
        private void OnValidate()
        {
            Drop?.Validate();
        }
#endif
    }
}