using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour {

    public Text counter;
    private MoneyManager manager = new MoneyManager();
    private List<string> suffixes = new List<string>()
    { "C", "KC", "MC", "GC", "TC", "PC", "EC", "YC", "ZC"};



    // Use this for initialization
    void Start () {
        counter.text = "0C";
    }
	
	// Update is called once per frame
	void Update () {
        manager.AddMoney(2000);
        SetMoney();    
	}    

    // Format the money string and set it
    void  SetMoney()  {
        string ms = manager.MoneyString();
        int len = manager.MoneyLength();
        int factor = (int) Mathf.Floor(len / 3);
        float cash = manager.get() / Mathf.Pow(1000, factor);


        string final = cash.ToString();
        //print(cash);
        counter.text = final + suffixes[factor];
    }
}
