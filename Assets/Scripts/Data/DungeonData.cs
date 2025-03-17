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
        [field:SerializeField] public RoomData[] Rooms { get; private set; }

        public RoomData GetRandomRoom()
        {
            return Rooms[Random.Range(0, Rooms.Length)];
        }
    }
}