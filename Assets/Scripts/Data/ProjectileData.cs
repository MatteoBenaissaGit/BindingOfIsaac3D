using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "Data/ProjectileData")]
    public class ProjectileData : ScriptableObject
    {
        [field:SerializeField] public float Speed { get; private set; }
        [field:SerializeField] public float Range { get; private set; }
        [field:SerializeField] public float Damage { get; private set; }
    }
}