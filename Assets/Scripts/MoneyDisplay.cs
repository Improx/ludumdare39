using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

    public TextMeshProUGUI MoneyDisplayText;
   
    private void Start () {
        MoneyDisplayText.text = "0C";

    } 

    public void SetDisplayAmount(long newAmount) {
        MoneyDisplayText.text = MoneyManager.MoneyString(newAmount);
    }
}
