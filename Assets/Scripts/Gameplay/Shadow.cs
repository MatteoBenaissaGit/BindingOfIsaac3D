using UnityEngine;

namespace Gameplay
{
    public class Shadow : MonoBehaviour
    {
        [SerializeField] private LayerMask _shadowFloorLayer;
        
        private void Update()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 100, _shadowFloorLayer))
            {
                transform.position = hit.point + Vector3.up * 0.1f;
            }
        }
    }
}