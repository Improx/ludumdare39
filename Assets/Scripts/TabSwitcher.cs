using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tabs;

    private void Start()
    {
        OpenTab(0);
    }

    public void OpenTab(int tabIndex)
    {
        foreach (var tab in _tabs)
        {
            tab.gameObject.SetActive(false);
        }
        _tabs[tabIndex].gameObject.SetActive(true);
    }
}
