using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Trump : MonoBehaviour
{
    private Animator _animator;
    private static readonly float _emoteDuration = 2f;
    private Emote _currentEmote;
    private float _emoteChanceTotal;

    private enum Emote
    {
        IDLE,
        CALLING,
        TYPING,
        NONE
    }

    private Dictionary<Emote, float> _emoteChances = new Dictionary<Emote, float>()
    {
        { Emote.IDLE, 1f },
        { Emote.CALLING, 0.01f },
        { Emote.TYPING, 0.01f },
    };

    private void Start()
    {
        _animator = GetComponent<Animator>();
        CalculateTotalChance();
    }

    private void CalculateTotalChance()
    {
        _emoteChanceTotal = 0;
        foreach (float chance in _emoteChances.Values)
        {
            _emoteChanceTotal += chance;
        }
    }

    private void Update()
    {
        float randomNum = Random.Range(0f, 1f);

        if (randomNum < 0.001f)
        {
            DoEmote(Emote.CALLING);
        }else if (randomNum > 0.001f && randomNum < 0.002f)
        {
            DoEmote(Emote.TYPING);
        }
        else
        {
            _currentEmote = Emote.IDLE;
        }
    }

    private void DoEmote(Emote newEmote)
    {
        if (_currentEmote != newEmote)
        {
            _currentEmote = newEmote;
            _animator.SetTrigger(newEmote.ToString());
        }

    }
}
