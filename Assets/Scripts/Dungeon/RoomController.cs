using UnityEngine;

namespace Dungeon
{
    /// <summary>
    /// This class is used to control the room game object
    /// </summary>
    public class RoomController : MonoBehaviour
    {
        [SerializeField] private Transform _defaultSpawnPoint;
        
        public Transform DefaultSpawnPoint => _defaultSpawnPoint;

        public void Set(Room room)
        {
            
        }
    }
}