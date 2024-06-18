using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoneySlot : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop called.");
        if (!item)
        {
            if (MoneyDragManager.beingDraggedItem != null)
            {
                MoneyDragManager.beingDraggedItem.transform.SetParent(transform);
                Debug.Log("Item dropped into empty slot.");
            }
            else
            {
                Debug.LogWarning("No item is being dragged.");
            }
        }
        else
        {
            Item dragItem = MoneyDragManager.beingDraggedItem?.GetComponent<Item>();
            Item slotItem = item.GetComponent<Item>();

            if (dragItem != null && slotItem != null && dragItem.itemName == slotItem.itemName && dragItem.number == slotItem.number)
            {
                int newNumber = dragItem.number + 1;
                Destroy(dragItem.gameObject);

                if (MoneyInventoryManager.inst != null)
                {
                    MoneyInventoryManager.inst.UpgradeExistingItem(slotItem, newNumber);
                    Debug.Log("Items merged: " + slotItem.itemName);
                }
                else
                {
                    Debug.LogError("MoneyInventoryManager.inst is null.");
                }
            }
            else
            {
                if (MoneyDragManager.beingDraggedItem != null)
                {
                    MoneyDragManager.beingDraggedItem.transform.SetParent(MoneyDragManager.beingDraggedItem.GetComponent<MoneyDragManager>().startParent);
                    MoneyDragManager.beingDraggedItem.transform.localPosition = Vector3.zero;
                    Debug.Log("Item returned to original slot.");
                }
                else
                {
                    Debug.LogWarning("No item is being dragged.");
                }
            }
        }
    }

    public void SetItem(Item newItem)
    {
        newItem.transform.SetParent(transform);
        newItem.transform.localPosition = Vector3.zero;
    }

    public bool IsEmpty()
    {
        return item == null;
    }
}

