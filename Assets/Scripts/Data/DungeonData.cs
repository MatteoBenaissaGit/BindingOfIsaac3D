using System;
using System.Collections.Generic;
using DungeonAndRoom;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Data
{
    [Serializable]
    public struct RoomsToDestroy
    {
        public List<Vector2Int> Coordinates;
    }
    
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
        [field:SerializeField] public RoomsToDestroy[] RoomsToDestroy { get; private set; }

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