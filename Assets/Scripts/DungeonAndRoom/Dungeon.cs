using System.Collections.Generic;
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
            
            //destroy room
            RoomsToDestroy roomsToDestroy = data.RoomsToDestroy[Random.Range(0, data.RoomsToDestroy.Length)];
            foreach (Vector2Int coordinate in roomsToDestroy.Coordinates)
            {
                Rooms[coordinate.x, coordinate.y] = null;
            }
            
            //setup doors for rooms
            for (int x = 0; x < data.Size.x; x++)
            {
                for (int y = 0; y < data.Size.y; y++)
                {
                    if (Rooms[x, y] == null) continue;
                    
                    Rooms[x, y].DownRoom = y > 0 ? Rooms[x, y - 1] : null;
                    Rooms[x, y].UpRoom = y < data.Size.y - 1 ? Rooms[x, y + 1] : null;
                    Rooms[x, y].LeftRoom = x > 0 ? Rooms[x - 1, y] : null;
                    Rooms[x, y].RightRoom = x < data.Size.x - 1 ? Rooms[x + 1, y] : null;
                }
            }
            
            List<Room> roomList = GetRoomList();
            
            //get random starting room
            CurrentRoom = roomList[Random.Range(0, roomList.Count)];
            CurrentRoom.RoomType = RoomType.Start;
            CurrentRoom.Instantiable = data.StartRoom;
            
            //set boss room
            Vector2Int bossCoordinates = new Vector2Int(Random.Range(0, data.Size.x), Random.Range(0, data.Size.y));
            int tries = 0;
            while ((bossCoordinates == CurrentRoom.Coordinates || Rooms[bossCoordinates.x,bossCoordinates.y] == null) && tries++ < 100)
            {
                bossCoordinates = new Vector2Int(Random.Range(0, data.Size.x), Random.Range(0, data.Size.y));

                if (tries >= 100)
                {
                    Debug.LogError("No boss room found, while > 100");
                }
            }
            Rooms[bossCoordinates.x, bossCoordinates.y].RoomType = RoomType.Boss;
            Rooms[bossCoordinates.x, bossCoordinates.y].Instantiable = data.GetRandomBossRoom();
        }

        public List<Room> GetRoomList()
        {
            var list = new List<Room>();
            for (int x = 0; x < Rooms.GetLength(0); x++)
            {
                for (int y = 0; y < Rooms.GetLength(1); y++)
                {
                    if (Rooms[x, y] == null) continue;
                    list.Add(Rooms[x,y]);
                }
            }
            return list;
        }
    }
}