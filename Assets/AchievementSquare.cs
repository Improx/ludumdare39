using System;
using Improx.Utility;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSquare : MonoBehaviour
{

    [SerializeField] private Image _iconImage;
    private AchievementInfo _achievement;

    public string AchName => _achievement.Name;
    public string AchDescription => _achievement.Description;
    public float AchReward => _achievement.PercentageReward;

    public void SetInfo(AchievementInfo newInfo)
    {
        _achievement = newInfo;
        string achName = _achievement.Id.ToString();
        int lastSeparatorIndex = achName.LastIndexOf("_", StringComparison.Ordinal);

        if (lastSeparatorIndex < 0)
        {
            throw new IndexOutOfRangeException(achName);
        }
        string spriteName = achName.Substring(0, lastSeparatorIndex);

        var achSprite = Resources.Load<Sprite>("Icons/Achievements/" + spriteName);

        if (achSprite == null)
        {
            Debug.LogWarning("Missing achievement sprite: " + spriteName);
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
