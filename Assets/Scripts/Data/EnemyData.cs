﻿using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public bool DamagePlayerOnContact { get; private set; } = true;
        [field: SerializeField] public int ContactDamage { get; private set; } = 1;
    }
}