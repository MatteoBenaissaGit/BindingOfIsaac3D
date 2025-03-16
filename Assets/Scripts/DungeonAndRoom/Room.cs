﻿namespace DungeonAndRoom
{
    /// <summary>
    /// This class handle a room's infos
    /// </summary>
    public class Room
    {
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