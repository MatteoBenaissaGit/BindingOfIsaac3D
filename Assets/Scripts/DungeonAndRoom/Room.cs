using System;
using Data;
using UnityEngine;

namespace DungeonAndRoom
{
    public enum RoomType
    {
        Start,
        Boss,
        Normal
    }

    /// <summary>
    /// This class handle a room's infos
    /// </summary>
    public class Room
    {
        public Room(InstantiableRoom instantiable)
        {
            Instantiable = instantiable;
        }
        
        public InstantiableRoom Instantiable { get; set; }
        public RoomType RoomType { get; set; }
        
        public Vector2Int Coordinates { get; set; }

        public bool HasUpRoom => UpRoom != null;
        public Room UpRoom;
        public bool HasLeftRoom => LeftRoom != null;
        public Room LeftRoom;
        public bool HasRightRoom => RightRoom != null;
        public Room RightRoom;
        public bool HasDownRoom => DownRoom != null;
        public Room DownRoom;
    }
}