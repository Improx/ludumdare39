using System;
using UnityEngine;

[Serializable]
public class BuyOptionData : GenericBuyOptionData
{
    public override long GetCostOfLevel(int level)
    {
        return (long)(StartingCost * Math.Pow(CostMultiplierPerLevel, level));
    }
}