using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

    private MoneyManager _moneymanager;
    public TextMeshProUGUI MoneyDisplayText;
   
    private void Start () {
        _moneymanager = MoneyManager.Instance();
        MoneyDisplayText.text = "0C";

    } 

    // Format the money string and set it
    public void SetDisplayAmount(long newAmount) {
        MoneyDisplayText.text = _moneymanager.MoneyString();
    }
}
