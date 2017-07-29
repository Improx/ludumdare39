using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSquare : MonoBehaviour
{

    [SerializeField] private Image _icon;
    private string _title;
    private string _description;

    public void Initialize(Sprite icon, string title, string description)
    {
        _icon.sprite = icon;
        _title = title;
        _description = description;
    }

    public void Unlock()
    {
        _icon.color = Color.white;
    }
}
