using Data;

namespace DungeonAndRoom
{
    /// <summary>
    /// This class handle the dungeon generation, structure & store the rooms
    /// </summary>
    public class Dungeon
    {
        public Room CurrentRoom { get; set; }

        private Room[,] _rooms;
        private DungeonData _data;
        
        public static Dungeon GenerateDungeon(DungeonData data)
        {
            var dungeon = new Dungeon();
            dungeon._data = data;
            
            dungeon.CurrentRoom = new Room();

            return dungeon;
        }
    }
}