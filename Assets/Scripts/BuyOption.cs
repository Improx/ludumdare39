using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyOption : MonoBehaviour
{
    private BuyOptionData _optionData;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _costText;
    private int _ownedAmount = 0;
    [SerializeField] private TextMeshProUGUI _ownedAmountText;
    [SerializeField] private Image _iconImage;

    public void Initialize(BuyOptionData data)
    {
        _optionData = data;
        SetTitle(_optionData.Name);
        SetCost(_optionData.StartingCost);
        SetIcon(_optionData.Icon);
    }

    private void SetTitle(string newTitle)
    {
        _titleText.text = newTitle;
    }

    private void SetCost(long newCost)
    {
        _costText.text = newCost.ToString();
    }

    private void SetOwnedAmount(int newAmount)
    {
        _ownedAmountText.text = newAmount.ToString();
    }

    private void SetIcon(Sprite newIcon)
    {
        _iconImage.sprite = newIcon;
    }

    public void Buy(int amount)
    {
        // Remove money
        // Increase income

        _ownedAmount = _ownedAmount + amount;
        SetOwnedAmount(_ownedAmount);
        SetCost(_optionData.GetCostOfLevel(_ownedAmount + 1));
    }
}
