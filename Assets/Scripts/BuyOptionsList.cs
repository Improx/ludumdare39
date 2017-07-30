using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyOptionsList : MonoBehaviour
{

    [SerializeField] private BuyOptionsCreator _buyOptions;
    [SerializeField] private GameObject _buyOptionParent;
    [SerializeField] private GameObject _buyOptionObject;

    private void Start()
    {
        _buyOptions.Options.Sort(
            (x, y) =>
            {
                var i = x.StartingCost < y.StartingCost ? -1 : 1;
                return i;
            });

        foreach (BuyOptionData buyOption in _buyOptions.Options)
        {
            GameObject obj = Instantiate(_buyOptionObject, _buyOptionParent.transform);
            obj.GetComponent<BuyOption>().Initialize(buyOption);
        }
    }
}
