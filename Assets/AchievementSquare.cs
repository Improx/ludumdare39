using System;
using System.Collections;
using System.Collections.Generic;
using Improx.Utility;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSquare : MonoBehaviour
{

    [SerializeField] private Image _iconImage;
    private AchievementInfo _achievement;

    public void SetInfo(AchievementInfo newInfo)
    {
        _achievement = newInfo;
        string achName = _achievement.Id.ToString();
        int lastSeparatorIndex = achName.LastIndexOf("_", StringComparison.Ordinal);
        string spriteName = achName.Substring(0, lastSeparatorIndex);

        var achSprite = Resources.Load<Sprite>("Icons/Achievements/" + spriteName);

        if (achSprite == null)
        {
            Debug.LogWarning("Missing achievement sprite: " + _achievement.Id);
            achSprite = Resources.Load<Sprite>("Icons/Achievements/MISSING_SPRITE");
        }
        _iconImage.sprite = achSprite;

        _achievement.OnUnlockedEvent.AddListener(Unlock);

    }

    public void Unlock()
    {
        _iconImage.color = _achievement.UnlockColor.Normalize();
    }
}
