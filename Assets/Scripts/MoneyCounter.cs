using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public long Money { get; private set; }
    public Text counter;

    public static MoneyCounter Instance;

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
	    Money = 0;
        counter.text = "0 C";
    }
	
	// Update is called once per frame
	void Update () {
	    //ney += 1531;
        //tMoney();    
	}

    // Getter
    long GetMoney()
    {
        return Money;
    }

    // Adder
    void AddMoney(long amount) {
        Money += amount;
    }

    // And this is för oski
    public void reduceMoney(long amount)
    {
        Money -= amount;
        print($"current money = {Money}");
    }

    // Format the money string and set it
    void  SetMoney()  {
        int length = Money.ToString().Length;
        string prefix = "";

        if (length > 6) prefix = "M";
        else if (length > 3) prefix = "K";

        string final = Money.ToString("N0");
        counter.text = final + prefix;

        
    }
}
