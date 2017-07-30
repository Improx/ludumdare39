using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    public static readonly List<AchievementInfo> Achievements = new List<AchievementInfo>
    {
        // Clicking
        new AchievementInfo("CLICKS_1", "First mistake", "Clicked once", 1),
        new AchievementInfo("CLICKS_100", "100 clicks", "Clicked 100 times", 1),
        new AchievementInfo("CLICKS_500", "500 clicks", "Clicked 500 times", 1),
        new AchievementInfo("CLICKS_2500", "2500 clicks", "Clicked 2500 times", 2),
        new AchievementInfo("CLICKS_10000", "10000 clicks", "Clicked 10000 times", 5),

        // Russian hackers
        new AchievementInfo("BUY_HACKERS_1", "Friend of Putin", "Hired a Russian hacker", 1),
        new AchievementInfo("BUY_HACKERS_5", "Red-faced", "Hired 5 Russian hackers", 5),
    };

    [SerializeField] private AchievementSquare _achievementSquareObject;
    [SerializeField] private Transform _achievementSquareParent;

    private void Start()
    {
        foreach (AchievementInfo achievementInfo in Achievements)
        {
            GameObject achSquareGameObject = Instantiate(_achievementSquareObject.gameObject, _achievementSquareParent);
            AchievementSquare achievementSquare = achSquareGameObject.GetComponent<AchievementSquare>();

            Sprite achSprite = Resources.Load<Sprite>("Icons/Achievements/" + achievementInfo.Id);
            achievementSquare.Initialize(achSprite, achievementInfo.Name, achievementInfo.Description);
        }
    }
}
