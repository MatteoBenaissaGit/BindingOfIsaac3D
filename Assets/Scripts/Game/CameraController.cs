using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        public void Shake(float duration = 0.5f)
        {
            transform.DOComplete();
            transform.DOShakePosition(duration);
        }
    }
}