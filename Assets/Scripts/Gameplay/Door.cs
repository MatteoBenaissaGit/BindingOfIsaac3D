using DG.Tweening;
using DungeonAndRoom;
using Game;
using UnityEngine;
using CharacterController = Character.CharacterController;

namespace Gameplay
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private float _openTweenTime;
        [SerializeField] private Ease _openTweenEase;
        [SerializeField] private float _closeTweenTime;
        [SerializeField] private Ease _closeTweenEase;
        
        private Room _room;
        private Vector3 _baseScale;

        private void Awake()
        {
            _baseScale = transform.localScale;
            transform.localScale = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<CharacterController>() == null) return;
            
            GameManager.Instance.SetNextRoom(_room);
        }

        public void Open(Room room)
        {
            _room = room;

            transform.DOComplete();
            
            gameObject.SetActive(true);
            transform.localScale = Vector3.zero;
            transform.DOScale(_baseScale, _openTweenTime).SetEase(_openTweenEase);
        }

        public void Close()
        {
            transform.DOComplete();
            transform.localScale = _baseScale;
            transform.DOScale(Vector3.zero, _closeTweenTime).SetEase(_closeTweenEase).OnComplete(() => gameObject.SetActive(false));
        }
    }
}
