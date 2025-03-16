using DungeonAndRoom;
using Game;
using UnityEngine;
using CharacterController = Character.CharacterController;

namespace Gameplay
{
    public class Door : MonoBehaviour
    {
        private Room _room;
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{other.gameObject.name}");
            if (other.gameObject.GetComponent<CharacterController>() == null) return;
            
            GameManager.Instance.SetNextRoom(_room);
        }

        public void Open(Room room)
        {
            gameObject.SetActive(true);
            _room = room;
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
