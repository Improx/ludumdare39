using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AchievementInfo
{
    public AchievementManager.Achievement Id;
    public string Name;
    public string Description;
    public int PercentageReward;
    public Color UnlockColor;

    public UnityEvent OnUnlockedEvent = new UnityEvent();
    private bool _unlocked;
    public bool Unlocked
    {
        get { return _unlocked; }
        set
        {
            _unlocked = value;

            if (_unlocked)
            {
                OnUnlockedEvent.Invoke();
            }
        }
    }

    public AchievementInfo(AchievementManager.Achievement id, long requirement, Color unlockColor, string name, string description, int percentageReward)
    {
        Id = id;
        Name = name;
        Description = description;
        PercentageReward = percentageReward;
        UnlockColor = unlockColor;
        Unlocked = false;
    }

}
