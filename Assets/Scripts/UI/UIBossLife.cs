using System;
using DG.Tweening;
using Enemy;
using UnityEngine;
using UnityEngine.UI;

public class UIBossLife : MonoBehaviour
{
    [SerializeField] private Image _lifeFillBar;

    private EnemyController _enemy;

    private void Start()
    {
        Hide();
    }

    public void Update(float fillAmount)
    {
        _lifeFillBar.DOComplete();
        _lifeFillBar.DOFillAmount(fillAmount, 0.1f);
    }
    
    public void Show(EnemyController enemy)
    {
        gameObject.SetActive(true);

        _enemy = enemy;
        _enemy.OnHit += Update;
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);

        if (_enemy != null)
        {
            _enemy.OnHit -= Update;
        }
    }
}
