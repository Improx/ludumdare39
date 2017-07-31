using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour {

    public TextMeshProUGUI MoneyDisplayText;
   
    private void Start () {
        MoneyDisplayText.text = "0C";

    } 

    public void SetDisplayAmount(long newAmount) {
        MoneyDisplayText.text = MoneyManager.MoneyString(newAmount);
    }
}
