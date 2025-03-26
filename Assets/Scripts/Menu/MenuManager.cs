using System;
using Inputs;
using MBLib.SingletonClassBase;
using UnityEngine;

namespace Menu
{
    public class MenuManager : Singleton<MenuManager>
    {
        [field:SerializeField] public Menu StartMenu { get; private set; }
        [field:SerializeField] public Menu CreditsMenu { get; private set; }

        public InputsManager Inputs => _inputs;
        
        private Menu _currentMenu;
        private InputsManager _inputs;

        protected override void InternalAwake()
        {
            _inputs = new InputsManager();
        }

        private void Start()
        {
            ShowMenu(StartMenu);
        }

        public void ShowMenu(Menu menu)
        {
            if (_currentMenu != null)
            {
                _currentMenu.Hide();
                _currentMenu.Enable = false;
            }
            
            _currentMenu = menu;
            _currentMenu.Show();
            _currentMenu.Enable = true;
        }
    }
}