using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BuyOptions", menuName = "BuyOptionsList", order = 1)]
public class BuyOptionsCreator : ScriptableObject
{
    public List<BuyOptionData> Options;
}
