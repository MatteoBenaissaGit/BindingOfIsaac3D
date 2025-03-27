using System;
using System.Collections.Generic;
using Enemy;
using Game;
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
        [Header("Prefabs")] 
        [SerializeField] private PickableItem _pickableItem;
        
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

            if (GameManager.Instance.DungeonController.CurrentRoom.RoomType == RoomType.Boss)
            {
                GameManager.Instance.UI.BossLife.Show(_enemies[0]);
                GameManager.Instance.UI.BossLife.UpdateLifeBar(1);
            }
        }

        public void AddEnemyToRoom(EnemyController enemy)
        {
            _enemies.Add(enemy);
            enemy.OnDie += CheckForRoomEnd;
        }
        
        private void CheckForRoomEnd(EnemyController deadEnemy)
        {
            if (IsBossEnd(deadEnemy))
            {
                return;
            }
            
            _enemies.Remove(deadEnemy);
            deadEnemy.OnDie -= CheckForRoomEnd;
            
            if (_enemies.Count <= 0)
            {
                EndRoom();
            }
        }

        private bool IsBossEnd(EnemyController enemyDead)
        {
            if (GameManager.Instance.DungeonController.CurrentRoom.RoomType != RoomType.Boss || enemyDead != _enemies[0])
            {
                return false;
            }
            
            GameManager.Instance.UI.BossLife.Hide();
            _enemies.Remove(enemyDead);
            enemyDead.OnDie -= CheckForRoomEnd;
            foreach (var enemy in _enemies)
            {
                enemy.Die(true);
                enemy.OnDie -= CheckForRoomEnd;
            }

            _enemies.Clear();

            GameManager.Instance.EndGame();

            return true;
        }

        private void EndRoom()
        {
            if (CurrentRoom.HasDownRoom) _downDoor.Open(CurrentRoom.DownRoom);
            if (CurrentRoom.HasUpRoom) _upDoor.Open(CurrentRoom.UpRoom);
            if (CurrentRoom.HasLeftRoom) _leftDoor.Open(CurrentRoom.LeftRoom);
            if (CurrentRoom.HasRightRoom) _rightDoor.Open(CurrentRoom.RightRoom);
        }
        
        public void SpawnPickableItem(Vector3 transformPosition, ItemType type, int amount)
        {
            transformPosition.y = 0.5f;
            Instantiate(_pickableItem, transformPosition, Quaternion.identity).Set(type, amount);
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