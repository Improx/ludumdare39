using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngineInternal.Input;

public class BuyAmountModifier : MonoBehaviour
{
    public static BuyAmountModifier Instance;

    private readonly Dictionary<KeyCode, int> _amountModifierDictionary = new Dictionary<KeyCode, int>()
    {
        {KeyCode.LeftControl, 10},
        {KeyCode.RightControl, 10},
        {KeyCode.LeftAlt, 25},
        {KeyCode.RightAlt, 25},
        {KeyCode.LeftShift, 100},
        {KeyCode.RightShift, 100},
    };

    public BuyAmountModifierChangedEvent OnModifierChangedEvent = new BuyAmountModifierChangedEvent();

    private int _currentModifier;
    public int CurrentModifier
    {
        get
        {
            return _currentModifier;
        }

        set
        {
            _currentModifier = value;
            OnModifierChangedEvent.Invoke(_currentModifier);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        foreach (KeyCode key in _amountModifierDictionary.Keys)
        {
            if (!Input.GetKey(key)) continue;

            CurrentModifier = _amountModifierDictionary[key];
            return;
        }
        CurrentModifier = 1;
    }
}
