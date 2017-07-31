using System.Collections.Generic;
using UnityEngine;

public class TabSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tabs;
    private readonly List<CanvasGroup> _canvasGroups = new List<CanvasGroup>();

    private void Start()
    {
        foreach (GameObject tab in _tabs)
        {
            _canvasGroups.Add(tab.GetComponent<CanvasGroup>());
        }

        OpenTab(0);
    }

    public void OpenTab(int tabIndex)
    {
        foreach (CanvasGroup tab in _canvasGroups)
        {
            CloseTab(tab);
        }

        OpenTab(_canvasGroups[tabIndex]);
    }

    private static void OpenTab(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private static void CloseTab(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
