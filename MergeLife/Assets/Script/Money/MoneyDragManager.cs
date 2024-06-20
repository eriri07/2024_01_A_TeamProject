using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class MoneyDragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beingDraggedItem;
    public Transform startParent;
    Vector3 startPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        beingDraggedItem = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        Debug.Log("Drag started: " + beingDraggedItem.name);

        SoundManager.instance.PlaySound("Coin1");

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beingDraggedItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }

        Debug.Log("Drag ended.");
    }
}
