using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;

public class ClickCatcher : MonoBehaviour
{

    private MoneyManager _moneyManager;
    [SerializeField] private Transform _trumpHolderTransform;
    private Vector3 _originalScale;
    private float _clickBounceMultiplier = 1.03f;

    private void Start()
    {
        _moneyManager = MoneyManager.Instance;
        _originalScale = _trumpHolderTransform.localScale;
    }

    private void OnMouseDown()
    {
        _moneyManager.AddMoney(1);
        DoClickEffect();
    }

    private void DoClickEffect()
    {
        
        TweenFactory.Tween("ScaleTrump", _originalScale, _trumpHolderTransform.localScale * _clickBounceMultiplier, 0.1f, TweenScaleFunctions.CubicEaseInOut,
            (t) =>
            {
                var currentValue = t.CurrentValue;
                currentValue.x = Mathf.Clamp(currentValue.x, _originalScale.x, _clickBounceMultiplier);
                currentValue.y = Mathf.Clamp(currentValue.x, _originalScale.y, _clickBounceMultiplier);
                currentValue.z = Mathf.Clamp(currentValue.x, _originalScale.z, _clickBounceMultiplier);
                _trumpHolderTransform.localScale = currentValue;
                
            }, (t) =>
            {
                TweenFactory.Tween("ScaleTrump", _trumpHolderTransform.localScale, _originalScale, 0.1f, TweenScaleFunctions.CubicEaseInOut,
                    (t2) =>
                    {
                        _trumpHolderTransform.localScale = t2.CurrentValue;
                    });
            });
    }
}
