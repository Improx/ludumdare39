using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class MoneyManager : MonoBehaviour
{

    public static MoneyManager Instance;

    public MoneyAmountChangedEvent OnMoneyChangedEvent = new MoneyAmountChangedEvent();

    private long _money;

    public long Money
    {
        get { return _money; }
        private set
        {
            if (value != _money) {
                OnMoneyChangedEvent.Invoke(value);
                _money = value;
                _moneyDisplay.SetDisplayAmount(_money);
            }
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

    [SerializeField]
    private MoneyDisplay _moneyDisplay;

    private void Awake()
    {
        Instance = this;
    }

    private void Start () {
        Money = 0;
    }

    private void Update()
    {
        //Money += 1;
    }

    // Adder
    public void AddMoney(long amount)
    {
        Money += amount;
    }

    // For buying stuff
    public void ReduceMoney(long amount)
    {
        Money -= amount;
    }
    
    // Format and return the money as a string
    public string MoneyString()
    {
        string MString = Money.ToString();
        int Len = MString.Length;
        int Factor = (int)Mathf.Floor((Len - 1) / 3);
        float Cash = Money / Mathf.Pow(1000, Factor);
        string Final = Cash.ToString("F3", CultureInfo.InvariantCulture);
        return Final + _suffixes[Factor];
    }



}
