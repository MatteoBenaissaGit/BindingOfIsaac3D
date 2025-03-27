using System;
using Character;
using Data;
using DungeonAndRoom;
using Gameplay;
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

        public RoomController RoomController => _roomController;
        public InputsManager Inputs { get; private set; }
        public Dungeon DungeonController { get; private set; }
        public CharacterController Character { get; private set; }

        private void Start()
        {
            Inputs = new InputsManager();

            InitializeCharacter();

            DungeonController = new Dungeon();
            DungeonController.GenerateDungeon(_dungeonData);

            UI.MiniMap.Initialize(DungeonController);
            
            SetNextRoom(DungeonController.CurrentRoom, true);
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

        public async void SetNextRoom(Room room, bool instant = false)
        {
            Character.Disable();
            if (instant == false)
            {
                await UI.FadeScreen.Show();
            }

            _roomController.Set(room);
            
            Vector3 offset = new Vector3(0, Character.TopDown.Height / 2, 0);
            var positionSpawn = _roomController.DefaultSpawnPoint.position + offset;
            if (DungeonController.CurrentRoom != room)
            {
                var roomOffset = DungeonController.CurrentRoom.Coordinates - room.Coordinates;
                positionSpawn += new Vector3(roomOffset.x,0,roomOffset.y) * 8;
            }
            Character.transform.SetPositionAndRotation(positionSpawn, _roomController.DefaultSpawnPoint.rotation);
            
            DungeonController.CurrentRoom = room;

            if (instant == false)
            {
                await UI.FadeScreen.Hide();
            }
            Character.Enable();
            
            UI.MiniMap.SetCurrentRoom(DungeonController.CurrentRoom.Coordinates, instant);
            _roomController.StartRoom();
        }
    }
}