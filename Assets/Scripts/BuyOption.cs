using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyOption : MonoBehaviour
{
    public BuyOptionData OptionData { get; private set; }
    private bool _optionUnlocked;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _ownedAmountText;
    [SerializeField] private TextMeshProUGUI _buyAmountText;

    [SerializeField] private Image _iconImage;
    [SerializeField] private Button _buyButton;

    private BuyAmountModifier _buyAmountModifier;
    private MoneyManager _moneyManager;
    public int OwnedAmount { get; private set; }
    private long _currentCost = 0;

    private float _lastMoneyEarnedTime = 0;

    public void Initialize(BuyOptionData data)
    {
        OptionData = data;
        SetTitle(OptionData.Name);
        SetCost(OptionData.StartingCost);
        SetIcon(OptionData.Icon);

        _buyAmountModifier = BuyAmountModifier.Instance;
        _buyAmountModifier.OnModifierChangedEvent.AddListener(SetBuyAmount);
        _buyAmountModifier.OnModifierChangedEvent.AddListener(amount => SetCost(CalculateCostForAmount(amount)));

        _moneyManager = MoneyManager.Instance;
        _moneyManager.OnMoneyChangedEvent.AddListener(CheckIfEnoughMoneyToUnlock);
        _moneyManager.OnMoneyChangedEvent.AddListener(CheckIfEnoughMoneyToBuy);

        SetActiveIfEnoughMoneyToUnlock(MoneyManager.Instance.Money);
        CheckIfEnoughMoneyToBuy(MoneyManager.Instance.Money);
    }

    private void OnDestroy()
    {
        // Unsubscribe from all events
        _moneyManager.OnMoneyChangedEvent.RemoveListener(CheckIfEnoughMoneyToUnlock);
        _moneyManager.OnMoneyChangedEvent.RemoveListener(CheckIfEnoughMoneyToBuy);
    }

    private void Update()
    {
        Update_HandleEarnings();
    }

    private void Update_HandleEarnings()
    {
        if (Time.timeSinceLevelLoad > _lastMoneyEarnedTime + OptionData.TickTimeInSeconds)
        {
            long moneyToEarn = OptionData.GetEarningsAtLevel(OwnedAmount);
            if (moneyToEarn > 0)
            {
                MoneyManager.Instance.AddMoney(moneyToEarn);
            }
            _lastMoneyEarnedTime = Time.timeSinceLevelLoad;
        }
    }

    private void SetActiveIfEnoughMoneyToUnlock(long currentMoney)
    {
        gameObject.SetActive(HasEnoughMoneyToUnlock(currentMoney));
    }

    private void CheckIfEnoughMoneyToUnlock(long currentMoney)
    {
        // If we haven't unlocked this option yet and we have enough money to show it, show it!
        if (_optionUnlocked == false && HasEnoughMoneyToUnlock(currentMoney))
        {
            gameObject.SetActive(true);
            _optionUnlocked = true;
            _moneyManager.OnMoneyChangedEvent.RemoveListener(CheckIfEnoughMoneyToUnlock);
        }
    }

    private bool HasEnoughMoneyToUnlock(long currentMoney)
    {
        return currentMoney >= OptionData.AvailableAtMoney;
    }

    private void CheckIfEnoughMoneyToBuy(long currentMoney)
    {
        // Show grayed out if we don't have enough money to buy
        _buyButton.interactable = currentMoney >= _currentCost;
    }

    private long CalculateCostForAmount(int amount)
    {
        return OptionData.GetCumulativeCostToLevel(OwnedAmount, OwnedAmount + amount);
    }

    private void SetTitle(string newTitle)
    {
        _titleText.text = newTitle;
    }

    private void SetCost(long newCost)
    {
        Debug.Assert(newCost > 0);
        _currentCost = newCost;
        _costText.text = MoneyManager.MoneyString(_currentCost);
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
        _buyAmountText.text = newAmount + "x";
    }

    public void Buy()
    {
        // Reduce money by current cost (takes into account modifier)
        MoneyManager.Instance.ReduceMoney(_currentCost);

        // Increase owned amount
        int amountToBuy = _buyAmountModifier.CurrentModifier;
        OwnedAmount = OwnedAmount + amountToBuy;
        SetOwnedAmount(OwnedAmount);

        // Set new cost
        SetCost(CalculateCostForAmount(OwnedAmount) * _buyAmountModifier.CurrentModifier);

        // Add achievement stat
        AchievementManager.Instance.AddBuyAchievementStat(OptionData.AssociatedAchievement, amountToBuy);
    }
}
