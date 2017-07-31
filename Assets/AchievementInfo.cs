using UnityEngine;
using UnityEngine.Events;

public class AchievementInfo : IIncomeMultiplier
{
    public AchievementManager.Achievement Id;
    public string Name;
    public string Description;
    public int PercentageReward;
    public Color UnlockColor;

    public UnityEvent OnUnlockedEvent = new UnityEvent();
    private bool _unlocked;
    public bool Unlocked
    {
        get { return _unlocked; }
        set
        {
            _unlocked = value;

            if (_unlocked)
            {
                SetUnlocked();
            }
        }
    }

    private void SetUnlocked()
    {
        MoneyManager.Instance.AddIncomeMultiplier(this);
        OnUnlockedEvent.Invoke();
    }

    public AchievementInfo(AchievementManager.Achievement id, long requirement, Color unlockColor, string name, string description, int percentageReward)
    {
        Id = id;
        Name = name;
        Description = description;
        PercentageReward = percentageReward;
        UnlockColor = unlockColor;
        Unlocked = false;
    }

    public float GetMultiplierIfUnlocked()
    {
        return Unlocked ? PercentageReward / 100f : 1;
    }
}
