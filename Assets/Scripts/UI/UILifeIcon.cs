using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UILifeIcon : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _fullSprite;
        [SerializeField] private Sprite _halfSprite;
        [SerializeField] private Sprite _missingSprite;

        public enum UILifeIconType
        {
            Full,
            Half,
            Missing
        }
        
        public void Set(UILifeIconType type)
        {
            _image.sprite = type switch
            {
                UILifeIconType.Full => _fullSprite,
                UILifeIconType.Half => _halfSprite,
                UILifeIconType.Missing => _missingSprite
            };
        }
    }
}