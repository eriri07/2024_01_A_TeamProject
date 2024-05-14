using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beingDraggedItem;
    Vector3 startPosition;
    Transform onDragParent;
    [HideInInspector]
    public Transform startParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        beingDraggedItem = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;

        onDragParent = InventoryManager.inst.transform;

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(onDragParent);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        beingDraggedItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (transform.parent == onDragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }
}
