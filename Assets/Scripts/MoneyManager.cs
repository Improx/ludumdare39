using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class MoneyManager : MonoBehaviour
{

    public static MoneyManager Instance;

    [SerializeField]
    private MoneyDisplay _moneyDisplay;

    public MoneyAmountChangedEvent OnMoneyChangedEvent = new MoneyAmountChangedEvent();
    private readonly List<IIncomeMultiplier> _incomeMultipliers = new List<IIncomeMultiplier>();

    private long _money;
    public long Money
    {
        get { return _money; }
        private set
        {
            if (value == _money) return;

            OnMoneyChangedEvent.Invoke(value);
            _money = value;
            _moneyDisplay.SetDisplayAmount(_money);
        }
    }

    public static readonly List<string> MoneySuffixes = new List<string>
    {
        "C",
        "KC",
        "MC",
        "GC",
        "TC",
        "PC",
        "EC",
        "YC",
        "ZC"
    };

    public static readonly string CurrencyName = "Controversy";

    private float _totalIncomeMultiplier = 1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start () {
        Money = 0;
        CalculateTotalIncomeMultiplier();
    }

    private void Update()
    {
        AddMoney(1000);
    }

    public void AddIncomeMultiplier(IIncomeMultiplier multiplier)
    {
        _incomeMultipliers.Add(multiplier);
        CalculateTotalIncomeMultiplier();
    }

    private void CalculateTotalIncomeMultiplier()
    {
        _totalIncomeMultiplier = 1;
        foreach (IIncomeMultiplier multiplier in _incomeMultipliers)
        {
            print(multiplier.GetMultiplierIfUnlocked());
            _totalIncomeMultiplier += multiplier.GetMultiplierIfUnlocked();
        }
        Stats.Instance.GameStats[StatType.TOTAL_MULTIPLIER] = (long)_totalIncomeMultiplier;
    }

    // Adder
    public void AddMoney(long amount)
    {
        long toAdd = (long)_totalIncomeMultiplier * amount;
        Money += toAdd;
        Stats.Instance.GameStats[StatType.CONTROVERSY_CAUSED] += toAdd;
    }

    // For buying stuff
    public void ReduceMoney(long amount)
    {
        Money -= amount;
    }

    // Format and return the money as a string
    public static string MoneyString(long newMoney)
    {
        string mString = newMoney.ToString();
        int mStringLength = mString.Length;

        int factor = (int)Mathf.Floor((mStringLength - 1) / 3) - 1;

        factor = factor < 0 ? 0 : factor;

        return (newMoney / Mathf.Pow(1000f, factor)).ToString(
                   "N0", CultureInfo.GetCultureInfoByIetfLanguageTag("en-US"))
               + MoneySuffixes[factor];
    }
}
