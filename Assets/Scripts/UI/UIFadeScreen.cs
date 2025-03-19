using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIFadeScreen : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _showTime = 0.2f;
        [SerializeField] private float _hideTime = 0.2f;

        public async Task Show()
        {
            _image.DOKill();
            _image.DOFade(1, _showTime);
            await Task.Delay((int)(_showTime * 1000));
        }
        
        public async Task Hide()
        {
            _image.DOKill();
            _image.DOFade(0, _hideTime);
            await Task.Delay((int)(_hideTime * 1000));
        }
    }
}