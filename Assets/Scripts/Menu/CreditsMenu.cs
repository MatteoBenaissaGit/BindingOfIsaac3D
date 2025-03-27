using UnityEngine;

namespace Menu
{
    public class CreditsMenu : Menu
    {
        [SerializeField] private Menu _startMenu;
        
        private void Start()
        {
            MenuManager.Instance.Inputs.OnMenuEscape += Quit;
        }
        
        private void Quit()
        {
            MenuManager.Instance.ShowMenu(_startMenu);
        }
    }
}