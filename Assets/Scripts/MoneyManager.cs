using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour {

    long money;

    public long get() { return money; }

    // Use this for initialization
    void Start () {
        money = 0;
    }
	
	// Update is called once per frame
	void Update () {
	}

    // Adder
    public void AddMoney(long amount)
    {
        money += amount;
    }

    // For buying stuff
    void reduceMoney(long amount)
    {
        money -= amount;
    }
    
    // Format and return the money as a string
    public string MoneyString()
    {
        return money.ToString();
    }

    // Length for suffix calculus
    public int MoneyLength()
    {
        return money.ToString().Length;
    }

}
