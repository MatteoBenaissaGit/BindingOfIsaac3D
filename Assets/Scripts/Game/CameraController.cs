using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        public void Shake()
        {
            transform.DOComplete();
            transform.DOShakePosition(0.5f);
        }
    }
}