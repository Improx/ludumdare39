using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Improx.Utility;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public static Stats Instance;

    [SerializeField] private TextMeshProUGUI _statsText;
    private bool _setTextNextTick = false;

    public ObservableConcurrentDictionary<StatType, long> GameStats = new ObservableConcurrentDictionary<StatType, long>
    {
        {StatType.TOTAL_CLICKS, 0},
        {StatType.CONTROVERSY_CAUSED, 0},
        {StatType.UPGRADES_BOUGHT, 0},
        {StatType.ACHIEVEMENTS_UNLOCKED, 0},
        {StatType.TOTAL_MULTIPLIER, 0},
    };

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameStats.PropertyChanged += (sender, args) => _setTextNextTick = true;
        SetStatText();
    }

    private void OnDestroy()
    {
        GameStats.PropertyChanged -= (sender, args) => _setTextNextTick = true;
    }

    private void Update()
    {
        if (!_setTextNextTick) return;

        SetStatText();
        _setTextNextTick = false;
    }

    private void SetStatText()
    {
        string newText = string.Empty;

        foreach (KeyValuePair<StatType, long> stat in GameStats)
        {
            string title = stat.Key.ToString().Replace("_", " ").ToLower().FirstLetterToUpper();
            string value = stat.Value.ToString();

            switch (stat.Key)
            {
                case StatType.CONTROVERSY_CAUSED:
                    value = MoneyManager.MoneyString(stat.Value);
                    break;
            }

            newText += $"{title}: {value}\n";
        }

        _statsText.text = newText;
    }
}

public enum StatType
{
    TOTAL_CLICKS,
    CONTROVERSY_CAUSED,
    UPGRADES_BOUGHT,
    ACHIEVEMENTS_UNLOCKED,
    TOTAL_MULTIPLIER,
}
