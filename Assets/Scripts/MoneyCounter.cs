using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour {

    private long money;
    public Text counter;

	// Use this for initialization
	void Start () {
        money = 0;
        counter.text = "0 C";
    }
	
	// Update is called once per frame
	void Update () {
        money += 1531;
        SetMoney();    
	}

    // Getter
    long GetMoney()
    {
        return money;
    }

    // Adder
    void AddMoney(long amount) {
        money += amount;
    }

    // And this is för oski
    void reduceMoney(long amount)
    {
        money -= amount;
    }

    // Format the money string and set it
    void  SetMoney()  {
        int length = money.ToString().Length;
        string prefix = "";

        if (length > 6) prefix = "M";
        else if (length > 3) prefix = "K";

        string final = money.ToString("N0");
        counter.text = final + prefix;
    }
}
