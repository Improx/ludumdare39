using System.Collections;
using System.Collections.Generic;
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
        return Money.ToString();
    }

    // Length for suffix calculus
    public int MoneyLength()
    {
        return Money.ToString().Length;
    }


}
