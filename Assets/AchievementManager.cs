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
        BUY_HACKERS_10,
        BUY_HACKERS_50,
        BUY_HACKERS_100,
        BUY_HACKERS_200,

        DENY_GLOBAL_WARMING_1,
        DENY_GLOBAL_WARMING_10,
        DENY_GLOBAL_WARMING_50,
        DENY_GLOBAL_WARMING_100,
        DENY_GLOBAL_WARMING_200,

        PUSSY_GRABBER_1,
        PUSSY_GRABBER_10,
        PUSSY_GRABBER_50,
        PUSSY_GRABBER_100,
        PUSSY_GRABBER_200,

        FIRE_PEOPLE_1,
        FIRE_PEOPLE_10,
        FIRE_PEOPLE_50,
        FIRE_PEOPLE_100,
        FIRE_PEOPLE_200,

        TWITTER_BOTS_1,
        TWITTER_BOTS_10,
        TWITTER_BOTS_50,
        TWITTER_BOTS_100,
        TWITTER_BOTS_200,

        ANTI_LGBT_1,
        ANTI_LGBT_10,
        ANTI_LGBT_50,
        ANTI_LGBT_100,
        ANTI_LGBT_200,

        FAKE_AUDIENCE_1,
        FAKE_AUDIENCE_10,
        FAKE_AUDIENCE_50,
        FAKE_AUDIENCE_100,
        FAKE_AUDIENCE_200,

        RICH_FRIENDS_1,
        RICH_FRIENDS_10,
        RICH_FRIENDS_50,
        RICH_FRIENDS_100,
        RICH_FRIENDS_200,

        SOLDIERS_1,
        SOLDIERS_10,
        SOLDIERS_50,
        SOLDIERS_100,
        SOLDIERS_200,

        WALL_1,
        WALL_10,
        WALL_50,
        WALL_100,
        WALL_200,


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
        new AchievementInfo(Achievement.BUY_HACKERS_10, 10, AchColors[AchSpriteColor.Silver], "Red-faced", "Hired 10 Russian hackers", 1),
        new AchievementInfo(Achievement.BUY_HACKERS_50, 50, AchColors[AchSpriteColor.Gold], "Red-faced", "Hired 50 Russian hackers", 2),
        new AchievementInfo(Achievement.BUY_HACKERS_100, 100, AchColors[AchSpriteColor.Blue], "Red-faced", "Hired 100 Russian hackers", 4),
        new AchievementInfo(Achievement.BUY_HACKERS_200, 200, AchColors[AchSpriteColor.Red], "Red-faced", "Hired 200 Russian hackers", 6),

        // Twitter bots
        new AchievementInfo(Achievement.TWITTER_BOTS_1, 1, AchColors[AchSpriteColor.Bronze], "You're fired!", "Buy one Twitter bot", 1),
        new AchievementInfo(Achievement.TWITTER_BOTS_10, 10, AchColors[AchSpriteColor.Silver], "Get out!", "Buy 10 Twitter bots", 1),
        new AchievementInfo(Achievement.TWITTER_BOTS_50, 50, AchColors[AchSpriteColor.Gold], "Who are these people?", "Buy 50 Twitter bots", 2),
        new AchievementInfo(Achievement.TWITTER_BOTS_100, 100, AchColors[AchSpriteColor.Blue], "If I'm going to clean house, they will come in as fresh blood", "Buy 100 Twitter bots", 4),
        new AchievementInfo(Achievement.TWITTER_BOTS_200, 200, AchColors[AchSpriteColor.Red], "Grab them by the p*ssy", "Buy 200 Twitter bots", 6),

        // Global warming
        new AchievementInfo(Achievement.DENY_GLOBAL_WARMING_1, 1, AchColors[AchSpriteColor.Bronze], "It's created by the Chinese", "Denied global warming once", 1),
        new AchievementInfo(Achievement.DENY_GLOBAL_WARMING_10, 10, AchColors[AchSpriteColor.Silver], "It's weather changes", "Denied global warming 10 times", 1),
        new AchievementInfo(Achievement.DENY_GLOBAL_WARMING_50, 50, AchColors[AchSpriteColor.Gold], "The biggest lie", "Denied global warming 50 times", 2),
        new AchievementInfo(Achievement.DENY_GLOBAL_WARMING_100, 100, AchColors[AchSpriteColor.Blue], "A total hoax", "Denied global warming 100 times", 4),
        new AchievementInfo(Achievement.DENY_GLOBAL_WARMING_200, 200, AchColors[AchSpriteColor.Red], "I don't believe in climate change", "Denied global warming 200 times", 6),

        // Pussy grabber
        new AchievementInfo(Achievement.PUSSY_GRABBER_1, 1, AchColors[AchSpriteColor.Bronze], "I better use some Tic Tacs", "Pussy grabbed once", 1),
        new AchievementInfo(Achievement.PUSSY_GRABBER_10, 10, AchColors[AchSpriteColor.Silver], "Just in case I start kissing her", "Pussy grabbed 10 times", 1),
        new AchievementInfo(Achievement.PUSSY_GRABBER_50, 50, AchColors[AchSpriteColor.Gold], "It's like a magnet", "Pussy grabbed 50 times", 2),
        new AchievementInfo(Achievement.PUSSY_GRABBER_100, 100, AchColors[AchSpriteColor.Blue], "You can do anything", "Pussy grabbed 100 times", 4),
        new AchievementInfo(Achievement.PUSSY_GRABBER_200, 200, AchColors[AchSpriteColor.Red], "Grab them by the p*ssy", "Pussy grabbed 200 times", 6),

        // People fired
        new AchievementInfo(Achievement.FIRE_PEOPLE_1, 1, AchColors[AchSpriteColor.Bronze], "You're fired!", "Fire one person", 1),
        new AchievementInfo(Achievement.FIRE_PEOPLE_10, 10, AchColors[AchSpriteColor.Silver], "Get out!", "Fire 10 people", 1),
        new AchievementInfo(Achievement.FIRE_PEOPLE_50, 50, AchColors[AchSpriteColor.Gold], "Who are these people?", "Fire 50 people", 2),
        new AchievementInfo(Achievement.FIRE_PEOPLE_100, 100, AchColors[AchSpriteColor.Blue], "I have fired many people", "Fire 100 people", 4),
        new AchievementInfo(Achievement.FIRE_PEOPLE_200, 200, AchColors[AchSpriteColor.Red], "Cleaning house", "Fire 200 people", 6),

        // Fake audience
        new AchievementInfo(Achievement.FAKE_AUDIENCE_1, 1, AchColors[AchSpriteColor.Bronze], "Woo!", "Use fake audience once", 1),
        new AchievementInfo(Achievement.FAKE_AUDIENCE_10, 10, AchColors[AchSpriteColor.Silver], "*Claps*", "Use fake audience 10 times", 1),
        new AchievementInfo(Achievement.FAKE_AUDIENCE_50, 50, AchColors[AchSpriteColor.Gold], "Look at that all these people!", "Use fake audience 50 times", 2),
        new AchievementInfo(Achievement.FAKE_AUDIENCE_100, 100, AchColors[AchSpriteColor.Blue], "Is that a real person?", "Use fake audience 100 times", 4),
        new AchievementInfo(Achievement.FAKE_AUDIENCE_200, 200, AchColors[AchSpriteColor.Red], "That guy must've been paid", "Use fake audience 200 times", 6),

        // Anti LGBT
        new AchievementInfo(Achievement.ANTI_LGBT_1, 1, AchColors[AchSpriteColor.Bronze], "No Love", "Hate on transgender once", 1),
        new AchievementInfo(Achievement.ANTI_LGBT_10, 10, AchColors[AchSpriteColor.Silver], "Fear of Rainbows", "Hate on transgender 10 times", 1),
        new AchievementInfo(Achievement.ANTI_LGBT_50, 50, AchColors[AchSpriteColor.Gold], "Rainbow in the Dark", "Hate on transgender 50 times", 2),
        new AchievementInfo(Achievement.ANTI_LGBT_100, 100, AchColors[AchSpriteColor.Blue], "No Rainbows here", "Hate on transgender 100 times", 4),
        new AchievementInfo(Achievement.ANTI_LGBT_200, 200, AchColors[AchSpriteColor.Red], "Unfabulous", "Hate on transgender 200 times", 6),

        // Rich friends
        new AchievementInfo(Achievement.RICH_FRIENDS_1, 1, AchColors[AchSpriteColor.Bronze], "Here you go", "Helped one rich friend", 1),
        new AchievementInfo(Achievement.RICH_FRIENDS_10, 10, AchColors[AchSpriteColor.Silver], "You owe me one", "Helped 10 rich friend", 1),
        new AchievementInfo(Achievement.RICH_FRIENDS_50, 50, AchColors[AchSpriteColor.Gold], "I've got something for you", "Helped 50 rich friends", 2),
        new AchievementInfo(Achievement.RICH_FRIENDS_100, 100, AchColors[AchSpriteColor.Blue], "I don't need your taxes", "Helped 100 rich friends", 4),
        new AchievementInfo(Achievement.RICH_FRIENDS_200, 200, AchColors[AchSpriteColor.Red], "We're good", "Helped 200 rich friends", 6),

        // Soldiers
        new AchievementInfo(Achievement.SOLDIERS_1, 1, AchColors[AchSpriteColor.Bronze], "Yes sir!", "Invest in soldiers once", 1),
        new AchievementInfo(Achievement.SOLDIERS_10, 10, AchColors[AchSpriteColor.Silver], "Safety First", "Invest in soldiers 10 times", 1),
        new AchievementInfo(Achievement.SOLDIERS_50, 50, AchColors[AchSpriteColor.Gold], "To protect the People", "Invest in soldiers 50 times", 2),
        new AchievementInfo(Achievement.SOLDIERS_100, 100, AchColors[AchSpriteColor.Blue], "We've got to make America strong again", "Invest in soldiers 100 times", 4),
        new AchievementInfo(Achievement.SOLDIERS_200, 200, AchColors[AchSpriteColor.Red], "There's nobody bigger or better at the military than I am", "Invest in soldiers 200 times", 6),

        // Wall bricks
        new AchievementInfo(Achievement.WALL_1, 1, AchColors[AchSpriteColor.Bronze], "I will build a great wall", "Start building the Wall", 1),
        new AchievementInfo(Achievement.WALL_10, 10, AchColors[AchSpriteColor.Silver], "I'll build them very inexpensively", "Stack 10 bricks on the Wall", 1),
        new AchievementInfo(Achievement.WALL_50, 50, AchColors[AchSpriteColor.Gold], "Mexico will pay for it!", "Stack 50 bricks on the Wall", 2),
        new AchievementInfo(Achievement.WALL_100, 100, AchColors[AchSpriteColor.Blue], "Mark my words", "Stack 100 bricks on the Wall", 4),
        new AchievementInfo(Achievement.WALL_200, 200, AchColors[AchSpriteColor.Red], "It's gonna be great!", "Stack 200 bricks on the Wall", 6),


    };

    [SerializeField] private AchievementSquare _achievementSquareObject;
    [SerializeField] private Transform _achievementSquareParent;

    #region AchievementStats

    public long TimesClicked;
    public long BoughtHackers;
    public long DeniedGlobalWarming;
    public long PussyGrabbers;
    public long PeopleFired;
    public long TwitterBots;
    public long AntiLgbt;
    public long FakeAudience;
    public long RichFriends;
    public long Soldiers;
    public long WallBricks;

    public void AddBuyAchievementStat(BuyAchievementType type, int amount)
    {
        switch (type)
        {
            case BuyAchievementType.Hackers:
                BoughtHackers += amount;
                break;
            case BuyAchievementType.GlobalWarming:
                DeniedGlobalWarming += amount;
                break;
            case BuyAchievementType.PussyGrabbers:
                PussyGrabbers += amount;
                break;
            case BuyAchievementType.PeopleFired:
                PeopleFired += amount;
                break;
            case BuyAchievementType.TwitterBots:
                TwitterBots += amount;
                break;
            case BuyAchievementType.AntiLgbt:
                AntiLgbt += amount;
                break;
            case BuyAchievementType.FakeAudience:
                FakeAudience += amount;
                break;
            case BuyAchievementType.RichFriends:
                RichFriends += amount;
                break;
            case BuyAchievementType.Soldiers:
                Soldiers += amount;
                break;
            case BuyAchievementType.WallBricks:
                WallBricks += amount;
                break;
            default:
                Debug.LogWarning("Achievement not found: " + type);
                return;
        }

        Stats.Instance.GameStats[StatType.UPGRADES_BOUGHT]++;
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
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.CLICKS_100:
                    if (TimesClicked >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.CLICKS_500:
                    if (TimesClicked >= 500)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.CLICKS_2500:
                    if (TimesClicked >= 2500)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.CLICKS_10000:
                    if (TimesClicked >= 10000)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.BUY_HACKERS_1:
                    if (BoughtHackers >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.BUY_HACKERS_10:
                    if (BoughtHackers >= 10)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.BUY_HACKERS_50:
                    if (BoughtHackers >= 50)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.BUY_HACKERS_100:
                    if (BoughtHackers >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.BUY_HACKERS_200:
                    if (BoughtHackers >= 200)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.DENY_GLOBAL_WARMING_1:
                    if (DeniedGlobalWarming >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.DENY_GLOBAL_WARMING_10:
                    if (DeniedGlobalWarming >= 10)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.DENY_GLOBAL_WARMING_50:
                    if (DeniedGlobalWarming >= 50)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.DENY_GLOBAL_WARMING_100:
                    if (DeniedGlobalWarming >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.DENY_GLOBAL_WARMING_200:
                    if (DeniedGlobalWarming >= 200)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.PUSSY_GRABBER_1:
                    if (PussyGrabbers >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.PUSSY_GRABBER_10:
                    if (PussyGrabbers >= 10)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.PUSSY_GRABBER_50:
                    if (PussyGrabbers >= 50)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.PUSSY_GRABBER_100:
                    if (PussyGrabbers >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.PUSSY_GRABBER_200:
                    if (PussyGrabbers >= 200)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.FIRE_PEOPLE_1:
                    if (PeopleFired >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.FIRE_PEOPLE_10:
                    if (PeopleFired >= 10)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.FIRE_PEOPLE_50:
                    if (PeopleFired >= 50)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.FIRE_PEOPLE_100:
                    if (PeopleFired >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.FIRE_PEOPLE_200:
                    if (PeopleFired >= 200)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.TWITTER_BOTS_1:
                    if (TwitterBots >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.TWITTER_BOTS_10:
                    if (TwitterBots >= 10)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.TWITTER_BOTS_50:
                    if (TwitterBots >= 50)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.TWITTER_BOTS_100:
                    if (TwitterBots >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.TWITTER_BOTS_200:
                    if (TwitterBots >= 200)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.ANTI_LGBT_1:
                    if (AntiLgbt >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.ANTI_LGBT_10:
                    if (AntiLgbt >= 10)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.ANTI_LGBT_50:
                    if (AntiLgbt >= 50)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.ANTI_LGBT_100:
                    if (AntiLgbt >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.ANTI_LGBT_200:
                    if (AntiLgbt >= 200)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.FAKE_AUDIENCE_1:
                    if (FakeAudience >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.FAKE_AUDIENCE_10:
                    if (FakeAudience >= 10)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.FAKE_AUDIENCE_50:
                    if (FakeAudience >= 50)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.FAKE_AUDIENCE_100:
                    if (FakeAudience >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.FAKE_AUDIENCE_200:
                    if (FakeAudience >= 200)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.RICH_FRIENDS_1:
                    if (RichFriends >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.RICH_FRIENDS_10:
                    if (RichFriends >= 10)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.RICH_FRIENDS_50:
                    if (RichFriends >= 50)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.RICH_FRIENDS_100:
                    if (RichFriends >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.RICH_FRIENDS_200:
                    if (RichFriends >= 200)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.SOLDIERS_1:
                    if (Soldiers >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.SOLDIERS_10:
                    if (Soldiers >= 10)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.SOLDIERS_50:
                    if (Soldiers >= 50)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.SOLDIERS_100:
                    if (Soldiers >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.SOLDIERS_200:
                    if (Soldiers >= 200)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.WALL_1:
                    if (WallBricks >= 1)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.WALL_10:
                    if (WallBricks >= 10)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.WALL_50:
                    if (WallBricks >= 50)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.WALL_100:
                    if (WallBricks >= 100)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                case Achievement.WALL_200:
                    if (WallBricks >= 200)
                    {
                        UnlockAchievement(achievement);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void UnlockAchievement(AchievementInfo achievement)
    {
        achievement.Unlocked = true;
        Stats.Instance.GameStats[StatType.ACHIEVEMENTS_UNLOCKED]++;
    }

    #endregion
}
