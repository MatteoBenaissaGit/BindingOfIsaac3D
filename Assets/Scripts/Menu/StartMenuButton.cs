using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class StartMenuButton : MonoBehaviour
    {
        [SerializeField] private Transform _arrowPosition;
        [Space(10)]
        [SerializeField] private Menu _menu;
        [SerializeField] private string _scene;
        
        public Vector3 ArrowPosition => _arrowPosition.position;

        public void OnClick()
        {
            if (_menu != null)
            {
                MenuManager.Instance.ShowMenu(_menu);
            }
            else if (string.IsNullOrEmpty(_scene) == false)
            {
                SceneManager.LoadScene(_scene);
            }
        }
    }
}