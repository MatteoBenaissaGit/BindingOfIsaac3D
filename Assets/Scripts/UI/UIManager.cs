using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [field:SerializeField] public UILifeController Life { get; private set; }
        [field:SerializeField] public UIStats Stats { get; private set; }
        [field:SerializeField] public UIMiniMap MiniMap { get; private set; }
    }
}