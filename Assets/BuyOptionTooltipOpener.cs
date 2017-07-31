using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyOptionTooltipOpener : GenericToolTipOpener
{
    private RectTransform _buyOptionHolder;
    private BuyOption _buyOption;
    private BuyOptionData _buyOptionData;

    private void Start()
    {
        _buyOption = GetComponent<BuyOption>();
        _buyOptionData = _buyOption.OptionData;
        _buyOptionHolder = transform.parent.parent.GetComponent<RectTransform>();
    }

    public override void OpenTooltipWithCurrentInfo()
    {
        base.OpenTooltipWithCurrentInfo();

        long currentEarnPerSecond = _buyOptionData.GetEarningsAtLevelPerSecond(_buyOption.OwnedAmount);
        string currentEarnPerSecondString = $"{MoneyManager.MoneyString(currentEarnPerSecond)}/s";

        long nextEarnPerSecond = _buyOptionData.GetEarningsAtLevelPerSecond(_buyOption.OwnedAmount + 1);
        string nextEarnPerSecondString = $"{MoneyManager.MoneyString(nextEarnPerSecond)}/s";

        string tooltipBody = $"Causing: {currentEarnPerSecondString}\nNext level: {nextEarnPerSecondString}";

        Tooltip.Instance.SetHolderContainer(_buyOptionHolder);
        Tooltip.Instance.SetContentsAndShow(_buyOptionData.Name, tooltipBody);
    }
}
