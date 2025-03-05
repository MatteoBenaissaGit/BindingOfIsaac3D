using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIStats : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bombText;
        [SerializeField] private TMP_Text _moneyText;

        public enum StatType
        {
            Bomb,
            Money
        }
        
        public void Set(StatType stat, int amount)
        {
            TMP_Text text = stat switch
            {
                StatType.Bomb => _bombText,
                StatType.Money => _moneyText,
            };
            if (amount < 10)
            {
                text.text = $"0{amount}";
                return;
            }
            text.text = amount.ToString();
        }
    }
}