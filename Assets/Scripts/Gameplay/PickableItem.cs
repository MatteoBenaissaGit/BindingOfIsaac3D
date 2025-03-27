using System;
using UnityEngine;

namespace Gameplay
{
    public enum ItemType
    {
        Life,
        Bomb,
        Money,
        None
    }

    [Serializable]
    public struct ItemInfos
    {
        public ItemType Type;
        public Sprite Icon;
    }
    
    [RequireComponent(typeof(SphereCollider))]
    public class PickableItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private ItemInfos[] _infos;
        
        private SphereCollider _collider;
        private ItemType _type;
        private int _amount;
        
        private void Start()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.isTrigger = true;
        }

        private Sprite GetIconFor(ItemType item)
        {
            foreach (ItemInfos info in _infos)
            {
                if (info.Type != item) continue;
                return info.Icon;
            }

            Debug.LogError("Item not found");
            return null;
        }

        public void Set(ItemType type, int amount)
        {
            _spriteRenderer.sprite = GetIconFor(type);
            _type = type;
            _amount = amount;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character.CharacterController character) == false) return;

            switch (_type)
            {
                case ItemType.Life:
                    character.AddLife(_amount);
                    break;
                case ItemType.Bomb:
                    character.AddBomb(_amount);
                    break;
                case ItemType.Money:
                    character.AddMoney(_amount);
                    break;
            } 
            
            Destroy(gameObject);
        }
    }
}