using System;
using System.Collections;
using System.Collections.Generic;
using Improx.Utility;
using UnityEngine;

public partial class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    public static readonly Dictionary<AchSpriteColor, Color> AchColors =
        new Dictionary<AchSpriteColor, Color>
        {
            {AchSpriteColor.Bronze, 0x4f351c.ToColor()},
            {AchSpriteColor.Silver, 0xadaba9.ToColor()},
            {AchSpriteColor.Gold, 0xf4aa42.ToColor()},
            {AchSpriteColor.Blue, 0x0e2577.ToColor()},
            {AchSpriteColor.Red, 0xa51c15.ToColor()},
        };

    public enum Achievement : int
    {
        CLICKS_1,
        CLICKS_100,
        CLICKS_500,
        CLICKS_2500,
        CLICKS_10000,

        BUY_HACKERS_1,
        BUY_HACKERS_5,
    };

    public static readonly List<AchievementInfo> Achievements = new List<AchievementInfo>
    {
        // Clicking
        new AchievementInfo(Achievement.CLICKS_1, 1, AchColors[AchSpriteColor.Bronze], "First mistake", "Clicked once", 1),
        new AchievementInfo(Achievement.CLICKS_100, 100, AchColors[AchSpriteColor.Silver], "100 clicks", "Clicked 100 times", 1),
        new AchievementInfo(Achievement.CLICKS_500, 500, AchColors[AchSpriteColor.Gold], "500 clicks", "Clicked 500 times", 1),
        new AchievementInfo(Achievement.CLICKS_2500, 2500, AchColors[AchSpriteColor.Blue], "2500 clicks", "Clicked 2500 times", 2),
        new AchievementInfo(Achievement.CLICKS_10000, 10000, AchColors[AchSpriteColor.Red], "10000 clicks", "Clicked 10000 times", 5),

        // Russian hackers
        new AchievementInfo(Achievement.BUY_HACKERS_1, 1, AchColors[AchSpriteColor.Bronze], "Friend of Putin", "Hired a Russian hacker", 1),
        new AchievementInfo(Achievement.BUY_HACKERS_5, 5, AchColors[AchSpriteColor.Silver], "Red-faced", "Hired 5 Russian hackers", 5),
    };

    [SerializeField] private AchievementSquare _achievementSquareObject;
    [SerializeField] private Transform _achievementSquareParent;

    #region AchievementStats

    public long TimesClicked;
    public long BoughtHackers;

    public void AddBuyAchievementStat(BuyAchievementType type, int amount)
    {
        switch (type)
        {
            case BuyAchievementType.Hackers:
                BoughtHackers += amount;
                break;
            default:
                Debug.LogWarning("Achievement not found: " + type);
                break;
        }
    }

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (AchievementInfo achievementInfo in Achievements)
        {
            GameObject achSquareGameObject = Instantiate(_achievementSquareObject.gameObject, _achievementSquareParent);
            var achievementSquare = achSquareGameObject.GetComponent<AchievementSquare>();
            achievementSquare.SetInfo(achievementInfo);
        }
    }

    private void Update()
    {
        Update_CheckAchievements();
    }

    #region AchievementChecks

    private void Update_CheckAchievements()
    {
        foreach (AchievementInfo achievement in Achievements)
        {
            if(achievement.Unlocked) continue;

            switch (achievement.Id)
            {
                case Achievement.CLICKS_1:
                    if (TimesClicked >= 1)
                    {
                        achievement.Unlocked = true;
                    }
                    break;
                case Achievement.CLICKS_100:
                    if (TimesClicked >= 100)
                    {
                        achievement.Unlocked = true;
                    }
                    break;
                case Achievement.CLICKS_500:
                    if (TimesClicked >= 500)
                    {
                        achievement.Unlocked = true;
                    }
                    break;
                case Achievement.CLICKS_2500:
                    if (TimesClicked >= 2500)
                    {
                        achievement.Unlocked = true;
                    }
                    break;
                case Achievement.CLICKS_10000:
                    if (TimesClicked >= 10000)
                    {
                        achievement.Unlocked = true;
                    }
                    break;
                case Achievement.BUY_HACKERS_1:
                    if (BoughtHackers >= 1)
                    {
                        achievement.Unlocked = true;
                    }
                    break;
                case Achievement.BUY_HACKERS_5:
                    if (BoughtHackers >= 5)
                    {
                        achievement.Unlocked = true;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    #endregion
}
