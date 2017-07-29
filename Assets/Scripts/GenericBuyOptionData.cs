using System;
using UnityEngine;

public class GenericBuyOptionData
{
    public string Name = "Option";
    public string Identifier = "Identifier";
    public string Description = @"This is an option";
    public Sprite Icon;
    public long StartingCost = 100;
    public long AvailableAtMoney = 0;
    public float CostMultiplierPerLevel = 1;

    public virtual long GetCostOfLevel(int level)
    {
        throw new NotImplementedException();
    }
}
