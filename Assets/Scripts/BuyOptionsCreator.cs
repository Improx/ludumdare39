using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BuyOptions", menuName = "BuyOptionsList", order = 1)]
public class BuyOptionsCreator : ScriptableObject
{
    public List<BuyOptionData> Options;

    private void OnValidate()
    {
        Options.Sort(
            (x, y) =>
            {
                var i = x.StartingCost < y.StartingCost ? -1 : 1;
                return i;
            });
    }
}
