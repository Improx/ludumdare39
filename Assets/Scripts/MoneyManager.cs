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

    private readonly List<string> _suffixes = new List<string>
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
        //Money += 1;
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
    }

    // Adder
    public void AddMoney(long amount)
    {
        Money += (long)_totalIncomeMultiplier * amount;
    }

    // For buying stuff
    public void ReduceMoney(long amount)
    {
        Money -= amount;
    }

    // Format and return the money as a string
    public string MoneyString(long NewMoney)
    {
        string MString = NewMoney.ToString();
        int Len = MString.Length;
        int Factor = (int)Mathf.Floor((Len - 1) / 3) - 1;
        if (Factor < 1){ return MString + _suffixes[0]; }
        float Cash = NewMoney / Mathf.Pow(1000, Factor);
        string Final = Cash.ToString("F3", CultureInfo.InvariantCulture);
        return Final + _suffixes[Factor];
    }
}
