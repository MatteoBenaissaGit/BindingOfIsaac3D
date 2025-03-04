using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; } = 10;
        [field:SerializeField] public float ShootCooldown { get; private set; }
    }
}