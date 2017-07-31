using System;
using UnityEngine;

public class GenericBuyOptionData
{
    public string Name = "Option";
    public string Description = @"This is an option";
    public Sprite Icon;
    public BuyAchievementType AssociatedAchievement;
    public long StartingCost = 100;
    public long AvailableAtMoney = 0;
    [Range(0, 1)]
    public float RateOfCostIncreasePerLevel = 1;
    public float EarningPerLevel = 10;
    public float TickTimeInSeconds = 1;

    public virtual long GetCostOfLevel(int level)
    {
        throw new NotImplementedException();
    }

    public virtual long GetCumulativeCostToLevel(int currentLevel, int targetLevel)
    {
        throw new NotImplementedException();
    }

    public long GetEarningsAtLevel(int level)
    {
        return (long)(level * EarningPerLevel);
    }

    public long GetEarningsAtLevelPerSecond(int level)
    {
        return (long)(GetEarningsAtLevel(level) / TickTimeInSeconds);
    }
}
