using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

    public TextMeshProUGUI MoneyDisplayText;
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

    private void Start () {
        MoneyDisplayText.text = "0C";
    } 

    // Format the money string and set it
    public void SetDisplayAmount(long newAmount) {
        string ms = newAmount.ToString();
        int len = ms.Length;
        int factor = (int) Mathf.Floor(len / 3);
        float cash = newAmount / Mathf.Pow(1000, factor);


        string final = cash.ToString(CultureInfo.InvariantCulture);
        MoneyDisplayText.text = final + _suffixes[factor];
    }
}
