/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beingDraggedItem;
    Vector3 startPosition;
    [HideInInspector]
    public Transform startParent;
    Canvas canvas;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        beingDraggedItem = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.worldCamera, out worldPoint);
        transform.position = canvas.transform.TransformPoint(worldPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beingDraggedItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (!eventData.pointerEnter || eventData.pointerEnter.GetComponent<Slot>() == null)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }
}


*/