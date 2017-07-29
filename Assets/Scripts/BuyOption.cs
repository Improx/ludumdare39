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
    [SerializeField] private Image _iconImage;

    public void Initialize(BuyOptionData data)
    {
        _optionData = data;
        SetTitle(_optionData.Name);
        SetCost(_optionData.GetCostOfLevel(1));
        print(_optionData.GetCostOfLevel(1) + " " + _optionData.CostMultiplierPerLevel + " " + _optionData.StartingCost);
        SetIcon(_optionData.Icon);
    }

    public void SetTitle(string newTitle)
    {
        _titleText.text = newTitle;
    }

    public void SetCost(long newCost)
    {
        _costText.text = newCost.ToString();
    }

    public void SetIcon(Sprite newIcon)
    {
        _iconImage.sprite = newIcon;
    }
}
