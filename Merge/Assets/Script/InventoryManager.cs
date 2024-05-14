using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inst;
    Slot[] inventorySlots;
    public Transform innerPanelTransform;
    public GameObject itemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        inst = this;
        inventorySlots = innerPanelTransform.GetComponentsInChildren<Slot>();
    }

    GameObject[] GetEmptyInventorySlots()
    {
        List<GameObject> emptySlots = new List<GameObject>();

        foreach (Slot s in inventorySlots)
        {
            if (s.item == null)
                emptySlots.Add(s.gameObject);
        }
        if (emptySlots.Count == 0)
            return null;
        else
            return emptySlots.ToArray();
    }

    public void CreateItem()
    {
        GameObject[] emptySlots = GetEmptyInventorySlots();

        if (emptySlots != null)
        {
            int randomNum = Random.Range(0, emptySlots.Length);

            var item = Instantiate(itemPrefab, emptySlots[randomNum].transform.position, Quaternion.identity);
            item.GetComponent<Item>().SetItem(1, emptySlots[randomNum].transform);
        }
    }

    public void CreateUpgradeItem(int newNumber, Transform newParent)
    {
        var item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        item.GetComponent<Item>().SetItem(newNumber, newParent);
    }
}
