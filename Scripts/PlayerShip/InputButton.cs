using UnityEngine;
using UnityEngine.EventSystems;

public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public bool IsDown { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsDown = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsDown = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsDown = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsDown = false;
    }
}
