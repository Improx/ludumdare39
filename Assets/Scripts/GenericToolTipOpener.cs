using UnityEngine;
using UnityEngine.EventSystems;

public abstract class GenericToolTipOpener : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public virtual void OpenTooltipWithCurrentInfo()
    {
        Tooltip.Instance.SetCurrentController(this);
    }

    public virtual void CloseTooltipIfSameController()
    {
        Tooltip.Instance.RemoveController(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OpenTooltipWithCurrentInfo();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CloseTooltipIfSameController();
    }
}
