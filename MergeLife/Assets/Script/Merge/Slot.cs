/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
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
            DragManager.beingDraggedItem.transform.SetParent(transform);
        }
        else
        {
            Item dragItem = DragManager.beingDraggedItem.GetComponent<Item>();
            Item slotItem = item.GetComponent<Item>();

            if (dragItem.itemType == slotItem.itemType && dragItem.number == slotItem.number)
            {
                int newNumber = dragItem.number + 1;
                Destroy(dragItem.gameObject);

                InventoryManager.inst.UpgradeExistingItem(slotItem, newNumber);

            }
            else
            {
                DragManager.beingDraggedItem.transform.SetParent(DragManager.beingDraggedItem.GetComponent<DragManager>().startParent);
                DragManager.beingDraggedItem.transform.localPosition = Vector3.zero;
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


*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
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
            DragManager.beingDraggedItem.transform.SetParent(transform);
        }
        else
        {
            Item dragItem = DragManager.beingDraggedItem.GetComponent<Item>();
            Item slotItem = item.GetComponent<Item>();

            if (dragItem.itemName == slotItem.itemName && dragItem.number == slotItem.number)
            {
                int newNumber = dragItem.number + 1;
                Destroy(dragItem.gameObject);

                InventoryManager.instance.UpgradeExistingItem(slotItem, newNumber); // 수정된 부분
            }
            else
            {
                DragManager.beingDraggedItem.transform.SetParent(DragManager.beingDraggedItem.GetComponent<DragManager>().startParent);
                DragManager.beingDraggedItem.transform.localPosition = Vector3.zero;
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
