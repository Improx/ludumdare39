using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementInfo
{
    public string Id;
    public string Name;
    public string Description;
    public int PercentageReward;
    public bool Unlocked;

    public AchievementInfo(string id, string name, string description, int percentageReward)
    {
        Id = id;
        Name = name;
        Description = description;
        PercentageReward = percentageReward;
        Unlocked = false;
    }

}
