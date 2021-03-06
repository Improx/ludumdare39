#define FORCE_SCREENRECT_TOOLTIP

using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public static Tooltip Instance;

    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private GameObject _toolTipObject;
    private RectTransform _toolTipObjectRect;

    public GenericToolTipOpener CurrentController { get; private set; }
    private RectTransform _holderContainer;
    private Vector3[] _holderCorners = new Vector3[4];

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _toolTipObjectRect = _toolTipObject.GetComponent<RectTransform>();
    }

    public void SetHolderContainer(RectTransform container)
    {
#if !FORCE_SCREENRECT_TOOLTIP
        _holderContainer = container;

        if (_holderContainer != null)
        {
            _holderContainer.GetWorldCorners(_holderCorners);
        }
#endif
    }

    public void SetCurrentController(GenericToolTipOpener controller)
    {
        CurrentController = controller;
    }

    public void RemoveController(GenericToolTipOpener controller)
    {
        if (CurrentController != controller) return;

        CurrentController = null;
        Hide();
    }

    public void SetContentsAndShow(string title, string description)
    {
        _titleText.text = title;
        _descriptionText.text = description;
        Show();
    }

    private void Update()
    {
        if (!CurrentController) return;

        Update_FollowMouse();
    }

    private void Update_FollowMouse()
    {
        _toolTipObject.transform.position = Input.mousePosition;

        float holderHalfWidth = 0;
        float holderHalfHeight = 0;

        if (_holderContainer == null)
        {
            holderHalfWidth = Screen.width / 2;
            holderHalfHeight = Screen.height / 2;
        }
        else
        {
            holderHalfWidth = (_holderCorners[3].x - _holderCorners[0].x) / 2;
            holderHalfHeight = (_holderCorners[1].y - _holderCorners[0].y) / 2;
        }

        Vector2 corner = Vector2.zero;
        corner.x = Input.mousePosition.x - _holderCorners[0].x > holderHalfWidth ? 1f : 0f;
        corner.y = Input.mousePosition.y - _holderCorners[0].y > holderHalfHeight ? 1f : 0f;

        _toolTipObjectRect.pivot = corner;
    }

    public void Show()
    {
        _toolTipObject.SetActive(true);
    }

    public void Hide()
    {
        _toolTipObject.SetActive(false);
    }
}

//_toolTipObject.transform.position = Input.mousePosition;

//Vector3[] objectCorners = new Vector3[4];
//_toolTipObjectRect.GetWorldCorners(objectCorners);
//bool isObjectOverflowing = false;

//foreach (Vector3 corner in objectCorners)
//{
//if (!_screenRect.Contains(corner))
//{
//isObjectOverflowing = true;
//break;
//}
//}

//if (isObjectOverflowing)
//_toolTipObject.transform.position = _lastPosition;

//_lastPosition = _toolTipObject.transform.position;

