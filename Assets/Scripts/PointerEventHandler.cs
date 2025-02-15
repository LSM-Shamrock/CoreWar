using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerEventHandler : MonoBehaviour, 
    IPointerMoveHandler, IPointerEnterHandler, IPointerExitHandler, 
    IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Action onPointerMove;
    public Action onPointerEnter;
    public Action onPointerExit;

    public Action onPointerDown;
    public Action onPointerUp;
    public Action onPointerClick;

    public void OnPointerMove(PointerEventData eventData)
    { onPointerMove?.Invoke(); }
    public void OnPointerEnter(PointerEventData eventData)
    { onPointerEnter?.Invoke(); }
    public void OnPointerExit(PointerEventData eventData)
    { onPointerExit?.Invoke(); }

    public void OnPointerDown(PointerEventData eventData)
    { onPointerDown?.Invoke(); }
    public void OnPointerUp(PointerEventData eventData)
    { onPointerUp?.Invoke(); }
    public void OnPointerClick(PointerEventData eventData)
    { onPointerClick?.Invoke(); }
}

