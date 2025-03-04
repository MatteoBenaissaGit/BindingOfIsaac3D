using Data;

namespace Dungeon
{
    /// <summary>
    /// This class handle the dungeon generation, structure & store the rooms
    /// </summary>
    public class Dungeon
    {
        public Room CurrentRoom { get; private set; }

        private Room[,] _rooms;
        private DungeonData _data;
        
        public void GenerateDungeon(DungeonData data)
        {
            _data = data;

            CurrentRoom = new Room();
        }
    }
}