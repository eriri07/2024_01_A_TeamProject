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
        if (!item)
        {
            MoneyDragManager.beingDraggedItem.transform.SetParent(transform);
        }
        else
        {
            Item dragItem = MoneyDragManager.beingDraggedItem.GetComponent<Item>();
            Item slotItem = item.GetComponent<Item>();

            if (dragItem.itemType == slotItem.itemType && dragItem.number == slotItem.number)
            {
                int newNumber = dragItem.number + 1;
                Destroy(dragItem.gameObject);

                MoneyInventoryManager.inst.UpgradeExistingItem(slotItem, newNumber);

            }
            else
            {
                MoneyDragManager.beingDraggedItem.transform.SetParent(MoneyDragManager.beingDraggedItem.GetComponent<MoneyDragManager>().startParent);
                MoneyDragManager.beingDraggedItem.transform.localPosition = Vector3.zero;
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


