using System.Collections.Generic;
using Enemy;
using Gameplay;
using UnityEngine;

namespace DungeonAndRoom
{
    /// <summary>
    /// This class is used to control the room game object
    /// </summary>
    public class RoomController : MonoBehaviour
    {
        [SerializeField] private Transform _defaultSpawnPoint;
        [SerializeField] private Door _upDoor, _downDoor, _leftDoor, _rightDoor;
        
        public Room CurrentRoom { get; private set; }
        public Transform DefaultSpawnPoint => _defaultSpawnPoint;

        private List<EnemyController> _enemies = new();

        public void Set(Room room)
        {
            _enemies.Clear();
            
            _downDoor.Close();
            _upDoor.Close();
            _leftDoor.Close();
            _rightDoor.Close();
            
            CurrentRoom = room;
        }

        public void StartRoom()
        {
            //TODO spawn enemies & objects
            //TODO sub to enemies die event
        }

        private void CheckForRoomEnd(EnemyController deadEnemy)
        {
            _enemies.Remove(deadEnemy);
            if (_enemies.Count <= 0)
            {
                EndRoom();
            }
        }

        private void EndRoom()
        {
            if (CurrentRoom.HasDownRoom) _downDoor.Open(CurrentRoom.DownRoom);
            if (CurrentRoom.HasUpRoom) _upDoor.Open(CurrentRoom.UpRoom);
            if (CurrentRoom.HasLeftRoom) _leftDoor.Open(CurrentRoom.LeftRoom);
            if (CurrentRoom.HasRightRoom) _rightDoor.Open(CurrentRoom.RightRoom);
        }
    }
}