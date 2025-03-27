using UnityEngine;

namespace Menu
{
    public abstract class Menu : MonoBehaviour
    {
        [field: SerializeField] protected CanvasGroup CanvasGroup { get; private set; }

        public bool Enable { get; set; }
        
        public virtual void Show()
        {
            CanvasGroup.alpha = 1;
            CanvasGroup.blocksRaycasts = true;
            CanvasGroup.interactable = true;
        }

        public virtual void Hide()
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.blocksRaycasts = true;
            CanvasGroup.interactable = true;
        }
    }
}