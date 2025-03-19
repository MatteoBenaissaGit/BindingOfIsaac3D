using DungeonAndRoom;
using UnityEngine;

namespace Data
{
    /// <summary>
    /// This scriptable object is used to store the dungeon generation data
    /// </summary>
    [CreateAssetMenu(fileName = "DungeonData", menuName = "Data/DungeonData")]
    public class DungeonData : ScriptableObject
    {
        [field:SerializeField] public Vector2Int Size { get; private set; }
        [field:SerializeField] public InstantiableRoom[] Rooms { get; private set; }
        [field:SerializeField] public InstantiableRoom[] BossRooms { get; private set; }
        [field:SerializeField] public InstantiableRoom StartRoom { get; private set; }

        public InstantiableRoom GetRandomRoom()
        {
            return Rooms[Random.Range(0, Rooms.Length)];
        }
        
        public InstantiableRoom GetRandomBossRoom()
        {
            return BossRooms[Random.Range(0, BossRooms.Length)];
        }
    }
}