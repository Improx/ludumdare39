using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRelativeToRect : MonoBehaviour
{

    [SerializeField] private RectTransform _targetRect;
    private Vector2 _startOffset = Vector2.zero;

    private void Start()
    {
        _startOffset = new Vector2(transform.position.x - _targetRect.position.x, transform.position.y - _targetRect.position.y);
    }

    private void Update()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height; // basically height * screen aspect ratio

        gameObject.transform.position = new Vector2(width * -0.22f, height * 0f);
        //gameObject.transform.localScale = Vector3.one * height / 6f;
    }
}
