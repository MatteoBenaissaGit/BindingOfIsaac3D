using DungeonAndRoom;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "RoomData", menuName = "Data/RoomData")]
    public class RoomData : ScriptableObject
    {
        [field:SerializeField] public InstantiableRoom LevelPrefab { get; private set; }
    }
}