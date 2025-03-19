using System;
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
        [SerializeField] private Transform _roomPrefabPosition;
        [SerializeField] private Door _upDoor, _downDoor, _leftDoor, _rightDoor;
        
        public Room CurrentRoom { get; private set; }
        public Transform DefaultSpawnPoint => _defaultSpawnPoint;
        
        private InstantiableRoom _currentRoomPrefab;
        private List<EnemyController> _enemies = new();

        public void Set(Room room)
        {
            _enemies.Clear();
            
            _downDoor.Close();
            _upDoor.Close();
            _leftDoor.Close();
            _rightDoor.Close();
            
            CurrentRoom = room;

            if (_currentRoomPrefab != null)
            {
                Destroy(_currentRoomPrefab.gameObject);
            }
            _currentRoomPrefab = Instantiate(room.Instantiable, _roomPrefabPosition.position, Quaternion.identity);
            
        }

        public void StartRoom()
        {
            if (_currentRoomPrefab.Enemies.Count <= 0)
            {
                EndRoom();
                return;
            }
            foreach (EnemyController enemy in _currentRoomPrefab.Enemies)
            {
                enemy.StartBehavior();
                enemy.OnDie += CheckForRoomEnd;
            }
            _enemies = new List<EnemyController>(_currentRoomPrefab.Enemies);
        }

        private void CheckForRoomEnd(EnemyController deadEnemy)
        {
            _enemies.Remove(deadEnemy);
            deadEnemy.OnDie -= CheckForRoomEnd;
            
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
        
        #if UNITY_EDITOR

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                _enemies[0].HitDamage(99999);    
            }
        }

#endif
    }
}