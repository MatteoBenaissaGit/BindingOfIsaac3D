using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UILifeController : MonoBehaviour
    {
        [SerializeField] private HorizontalOrVerticalLayoutGroup _layout;
        [SerializeField] private UILifeIcon _uiLifeIcon;

        private List<UILifeIcon> _icons = new();
        private int _currentLife;
        private int _currentMaxLife;
        
        public void Initialize(int life, int maxLife)
        {
            _currentMaxLife = maxLife;
            _currentLife = life;
            
            for (int i = 0; i < maxLife;)
            {
                UILifeIcon.UILifeIconType type = maxLife > i + 1 ? UILifeIcon.UILifeIconType.Full : UILifeIcon.UILifeIconType.Half;
                SpawnUIIcon(type);
                i += type == UILifeIcon.UILifeIconType.Full ? 2 : 1;
            }
        }

        public void UpdateLife(int life)
        {
            _currentLife = life;
            
            for (int i = 0; i < _currentMaxLife;)
            {
                UILifeIcon.UILifeIconType type = UILifeIcon.UILifeIconType.Full;
                if (i < _currentLife && i + 1 >= _currentLife)
                {
                    type = UILifeIcon.UILifeIconType.Half;
                }
                if (i >= _currentLife)
                {
                    type = UILifeIcon.UILifeIconType.Missing;
                }
                _icons[i/2].Set(type);
                
                i += 2;
            }
        }

        public void AddMaxLife(int increment)
        {
            _currentMaxLife += increment;
        }

        private void SpawnUIIcon(UILifeIcon.UILifeIconType type)
        {
            UILifeIcon icon = Instantiate(_uiLifeIcon, _layout.transform);
            icon.Set(type);
            _icons.Add(icon);
        }
    }
}