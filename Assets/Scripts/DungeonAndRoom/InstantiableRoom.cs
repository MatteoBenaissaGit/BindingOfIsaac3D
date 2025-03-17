using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace DungeonAndRoom
{
    public class InstantiableRoom : MonoBehaviour
    {
        [field: SerializeField] public List<EnemyController> Enemies { get; private set; } = new();
    }
}