using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTooltipOpener : GenericToolTipOpener
{
    private RectTransform _achievementHolder;
    private AchievementSquare _achievementSquare;

    private void Start()
    {
        _achievementSquare = GetComponent<AchievementSquare>();
        _achievementHolder = transform.parent.parent.GetComponent<RectTransform>();
    }

    public override void OpenTooltipWithCurrentInfo()
    {
        base.OpenTooltipWithCurrentInfo();

        string tooltipBody = $"{_achievementSquare.AchDescription}.\n\nReward: +{_achievementSquare.AchReward}%"; 

        Tooltip.Instance.SetHolderContainer(_achievementHolder);
        Tooltip.Instance.SetContentsAndShow(_achievementSquare.AchName, tooltipBody);
    }
}
