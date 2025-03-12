using System;
using UnityEngine;
using CharacterController = Character.CharacterController;

namespace Gameplay
{
    public class Door : MonoBehaviour
    {
        public Action OnPlayerEnterDoor { get; set; }
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{other.gameObject.name}");
            if (other.gameObject.GetComponent<CharacterController>() == null) return;
            OnPlayerEnterDoor?.Invoke();
        }
    }
}
