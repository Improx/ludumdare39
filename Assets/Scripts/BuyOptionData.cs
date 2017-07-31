using System;
using UnityEngine;

[Serializable]
public class BuyOptionData : GenericBuyOptionData
{
    public override long GetCostOfLevel(int level)
    {
        return Mathf.FloorToInt(
            StartingCost - 5000 + 5000 * Mathf.Pow(100, 0.002f * RateOfCostIncreasePerLevel * level));
        //return Mathf.FloorToInt(5 / Mathf.Pow(level, -RateOfCostIncreasePerLevel) + StartingCost);
    }

    public override long GetCumulativeCostToLevel(int currentLevel, int targetLevel)
    {
        //long cost = GetCostOfLevel(currentLevel);
        long cost = 0;

        for (int i = currentLevel + 1; i <= targetLevel; i++)
        {
            cost += Mathf.FloorToInt(
                StartingCost - 5000 + 5000 * Mathf.Pow(100, 0.002f * RateOfCostIncreasePerLevel * i));

            //cost += Mathf.FloorToInt(5 / Mathf.Pow(i, -RateOfCostIncreasePerLevel) + StartingCost);
        }

        //double cost = 
        //    // ReSharper disable once ComplexConditionExpression
        //    costOfCurrentLevel 
        //    * (1 - Math.Pow(RateOfCostIncreasePerLevel, targetLevel - currentLevel)) 
        //    / (1 - RateOfCostIncreasePerLevel);

        //long longCost = Mathf.FloorToInt((float)cost);

        if (cost < 0)
        {
            cost = long.MaxValue;
        }

        return cost;
    }
}