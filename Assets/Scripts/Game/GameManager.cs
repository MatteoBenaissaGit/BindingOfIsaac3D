using System;
using Character;
using Data;
using DungeonAndRoom;
using Inputs;
using MBLib.SingletonClassBase;
using UI;
using UnityEngine;
using CharacterController = Character.CharacterController;

namespace Game
{
    public class GameManager : Singleton<GameManager>
    {
        [field:SerializeField] public CameraController CameraController { get; private set; }
        [field:SerializeField] public UIManager UI { get; private set; }
        
        [Header("Game")]
        [SerializeField] private CharacterController _characterPrefab;
        [SerializeField] private DungeonData _dungeonData;
        [SerializeField] private RoomController _roomController;

        public InputsManager Inputs { get; private set; }
        public Dungeon DungeonController { get; private set; }
        public CharacterController Character { get; private set; }

        private void Start()
        {
            Inputs = new InputsManager();
            Inputs.Initialize();

            InitializeCharacter();

            DungeonController = new Dungeon();
            DungeonController.GenerateDungeon(_dungeonData);
            
            SetNextRoom(DungeonController.CurrentRoom);
        }

        private void Update()
        {
            Inputs.Update();
        }


        private void InitializeCharacter()
        {
            Character = Instantiate(_characterPrefab);
            
            Vector3 offset = new Vector3(0, Character.TopDown.Height / 2, 0);
            Character.transform.SetPositionAndRotation(_roomController.DefaultSpawnPoint.position + offset, _roomController.DefaultSpawnPoint.rotation);
        }

        public void SetNextRoom(Room room)
        {
            DungeonController.CurrentRoom = room;
            
            _roomController.Set(room);
            
            Vector3 offset = new Vector3(0, Character.TopDown.Height / 2, 0);
            Character.transform.SetPositionAndRotation(_roomController.DefaultSpawnPoint.position + offset, _roomController.DefaultSpawnPoint.rotation);
            
            _roomController.StartRoom();
        }
    }
}