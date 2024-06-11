/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IDropHandler
{
    internal static object inst;

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
            Item soltItem = item.GetComponent<Item>();

            if (dragItem.number == soltItem.number)
            {
                int backupNum = dragItem.number;
                Destroy(dragItem.gameObject); Destroy(soltItem.gameObject);

                InventoryManager.inst.CreateUpgradeItem(backupNum + 1, transform);
            }
            else
            {
                DragManager.beingDraggedItem.transform.SetParent(transform);
                item.transform.SetParent(DragManager.beingDraggedItem.GetComponent<DragManager>().startParent);
            }
        }
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

            // 아이템 유형이 같고 숫자가 같은 경우에만 머지
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


