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
    [SerializeField] private TextMeshProUGUI _ownedAmountText;
    [SerializeField] private TextMeshProUGUI _buyAmountText;

    [SerializeField] private Image _iconImage;

    private BuyAmountModifier _buyAmountModifier;
    private int _ownedAmount = 0;
    private long _currentCost = 0;

    private float lastMoneyEarnedTime = 0;

    public void Initialize(BuyOptionData data)
    {
        _optionData = data;
        SetTitle(_optionData.Name);
        SetCost(_optionData.StartingCost);
        SetIcon(_optionData.Icon);

        _buyAmountModifier = BuyAmountModifier.Instance;
        _buyAmountModifier.OnModifierChangedEvent.AddListener(SetBuyAmount);
        _buyAmountModifier.OnModifierChangedEvent.AddListener((amount) => SetCost(CalculateCostForAmount(amount)));
    }

    private void Update()
    {
        Update_HandleEarnings();
    }

    private void Update_HandleEarnings()
    {
        if (Time.timeSinceLevelLoad > lastMoneyEarnedTime + _optionData.TickTimeInSeconds)
        {
            long moneyToEarn = _optionData.GetEarningsAtLevel(_ownedAmount);
            if (moneyToEarn > 0)
            {
                //print("earned money " + _optionData.Name + " " + lastMoneyEarnedTime);
                MoneyCounter.Instance.AddMoney(moneyToEarn);
            }
            lastMoneyEarnedTime = Time.timeSinceLevelLoad;
        }
    }

    private long CalculateCostForAmount(int amount)
    {
        return _optionData.GetCumulativeCostToLevel(_ownedAmount, _ownedAmount + amount);
    }

    private void SetTitle(string newTitle)
    {
        _titleText.text = newTitle;
    }

    private void SetCost(long newCost)
    {
        Debug.Assert(newCost > 0);
        _currentCost = newCost;
        print(newCost);
        _costText.text = _currentCost.ToString();
    }

    private void SetOwnedAmount(int newAmount)
    {
        _ownedAmountText.text = newAmount.ToString();
    }

    private void SetIcon(Sprite newIcon)
    {
        _iconImage.sprite = newIcon;
    }

    private void SetBuyAmount(int newAmount)
    {
        _buyAmountText.text = newAmount.ToString() + "x";
    }

    public void Buy()
    {
        // Reduce money by current cost (takes into account modifier)
        MoneyCounter.Instance.reduceMoney(_currentCost);

        // Increase owned amount
        _ownedAmount = _ownedAmount + _buyAmountModifier.CurrentModifier;
        SetOwnedAmount(_ownedAmount);

        // Set new cost
        SetCost(_optionData.GetCostOfLevel(_ownedAmount));
    }
}
