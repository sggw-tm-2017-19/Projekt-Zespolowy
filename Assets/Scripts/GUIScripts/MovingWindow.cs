using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class MovingWindow : MonoBehaviour, IPointerDownHandler, IDragHandler {
    private Vector2 pointerOffset;
    private RectTransform canvasRectTransform;
    private RectTransform gameObjectRectTransform;
    void Awake()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        canvasRectTransform = canvas.transform as RectTransform;
        gameObjectRectTransform = transform as RectTransform;
    }
    public void OnPointerDown (PointerEventData data)
    {
        gameObjectRectTransform.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(gameObjectRectTransform, data.position, data.pressEventCamera, out pointerOffset);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (gameObjectRectTransform == null)
            return;

        Vector2 localPointerPosition;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle (
            canvasRectTransform, eventData.position,eventData.pressEventCamera,out localPointerPosition))
        {
            gameObjectRectTransform.localPosition = localPointerPosition - pointerOffset;
        }
    }

    
}
