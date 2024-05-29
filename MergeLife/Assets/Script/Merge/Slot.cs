using System.Collections;
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
