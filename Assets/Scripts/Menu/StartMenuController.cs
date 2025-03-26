using UnityEngine;

namespace Menu
{
    public class StartMenuController : Menu
    {
        [Header("Start Menu")] 
        [SerializeField] private StartMenuButton[] _button;
        [SerializeField] private Transform _arrow;

        private int _currentButtonIndex;

        private void Start()
        {
            _currentButtonIndex = 0;
            UpdateArrowPosition();

            MenuManager.Instance.Inputs.OnMenuDown += Down;
            MenuManager.Instance.Inputs.OnMenuUp += Up;
            MenuManager.Instance.Inputs.OnMenuEnter += Enter;
        }

        private void UpdateArrowPosition()
        {
            _arrow.position = _button[_currentButtonIndex].ArrowPosition;
        }

        private void Down()
        {
            if (Enable == false) return;
            _currentButtonIndex++;
            if (_currentButtonIndex >= _button.Length)
            {
                _currentButtonIndex = 0;
            }
            UpdateArrowPosition();
        }

        private void Up()
        {
            if (Enable == false) return;
            _currentButtonIndex--;
            if (_currentButtonIndex < 0)
            {
                _currentButtonIndex = _button.Length - 1;
            }
            UpdateArrowPosition();
        }

        private void Enter()
        {
            if (Enable == false) return;
            _button[_currentButtonIndex].OnClick();
        }
    }
}