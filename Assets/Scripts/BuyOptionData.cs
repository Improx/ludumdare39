using System;
using UnityEngine;

[Serializable]
public class BuyOptionData : GenericBuyOptionData
{
    public override long GetCostOfLevel(int level)
    {
        return (long)(StartingCost * Math.Pow(CostMultiplierPerLevel, level));
    }

    public override long GetCumulativeCostToLevel(int currentLevel, int targetLevel)
    {
        long costOfCurrentLevel = GetCostOfLevel(currentLevel);

        double cost = 
            // ReSharper disable once ComplexConditionExpression
            costOfCurrentLevel 
            * (1 - Math.Pow(CostMultiplierPerLevel, targetLevel - currentLevel)) 
            / (1 - CostMultiplierPerLevel);

        long longCost = Mathf.CeilToInt((float)cost);

        return longCost;
    }
}