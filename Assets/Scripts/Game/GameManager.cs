using System;
using Character;
using Data;
using Dungeon;
using Inputs;
using MBLib.SingletonClassBase;
using UnityEngine;
using CharacterController = Character.CharacterController;

namespace Game
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Game")]
        [SerializeField] private CharacterController _characterPrefab;
        [SerializeField] private DungeonData _dungeonData;
        [SerializeField] private RoomController _room;
        
        public InputsManager Inputs { get; private set; }
        public Dungeon.Dungeon Dungeon { get; private set; }
        public CharacterController Character { get; private set; }

        private void Start()
        {
            Inputs = new InputsManager();
            Inputs.Initialize();

            Dungeon = new Dungeon.Dungeon();
            Dungeon.GenerateDungeon(_dungeonData);
            
            _room.Set(Dungeon.CurrentRoom);
            
            InitializeCharacter();
        }

        private void Update()
        {
            Inputs.Update();
        }


        private void InitializeCharacter()
        {
            Character = Instantiate(_characterPrefab);
            Vector3 offset = new Vector3(0, Character.TopDown.Height / 2, 0);
            Character.transform.SetPositionAndRotation(_room.DefaultSpawnPoint.position + offset, _room.DefaultSpawnPoint.rotation);
        }
    }
}