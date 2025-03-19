using Data;
using UnityEngine;

namespace DungeonAndRoom
{
    /// <summary>
    /// This class handle the dungeon generation, structure & store the rooms
    /// </summary>
    public class Dungeon
    {
        public Room CurrentRoom { get; set; }
        public Room[,] Rooms { get; private set; }
        public Vector2Int Size => new(_data.Size.x, _data.Size.y);
        
        private Room[,] _rooms;
        private DungeonData _data;
        
        public void GenerateDungeon(DungeonData data)
        {
            _data = data;

            //create array and rooms
            Rooms = new Room[data.Size.x, data.Size.y];
            for (int x = 0; x < data.Size.x; x++)
            {
                for (int y = 0; y < data.Size.y; y++)
                {
                    Rooms[x, y] = new Room(_data.GetRandomRoom());
                    Rooms[x, y].Coordinates = new Vector2Int(x, y);
                }
            }
            
            //setup doors for rooms
            for (int x = 0; x < data.Size.x; x++)
            {
                for (int y = 0; y < data.Size.y; y++)
                {
                    Rooms[x, y].DownRoom = y > 0 ? Rooms[x, y - 1] : null;
                    Rooms[x, y].UpRoom = y < data.Size.y - 1 ? Rooms[x, y + 1] : null;
                    Rooms[x, y].LeftRoom = x > 0 ? Rooms[x - 1, y] : null;
                    Rooms[x, y].RightRoom = x < data.Size.x - 1 ? Rooms[x + 1, y] : null;
                }
            }

            //get random starting room
            CurrentRoom = Rooms[Random.Range(0, data.Size.x), Random.Range(0, data.Size.y)];
            CurrentRoom.RoomType = RoomType.Start;
            CurrentRoom.Instantiable = data.StartRoom;
            
            //set boss room
            Vector2Int bossCoordinates = new Vector2Int(Random.Range(0, data.Size.x), Random.Range(0, data.Size.y));
            int tries = 0;
            while (bossCoordinates == CurrentRoom.Coordinates && tries++ < 100)
            {
                bossCoordinates = new Vector2Int(Random.Range(0, data.Size.x), Random.Range(0, data.Size.y));
            }
            Rooms[bossCoordinates.x, bossCoordinates.y].RoomType = RoomType.Boss;
            Rooms[bossCoordinates.x, bossCoordinates.y].Instantiable = data.GetRandomBossRoom();
        }
    }
}