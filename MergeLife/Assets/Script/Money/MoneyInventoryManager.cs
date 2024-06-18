/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInventoryManager : MonoBehaviour
{
    public static MoneyInventoryManager inst;
    MoneySlot[] inventorySlots;
    public Transform innerPanelTransform;

    public List<GameObject> itemPrefabs;

    public MoneyManager moneyManager;

    void Start()
    {
        inst = this;
        inventorySlots = innerPanelTransform.GetComponentsInChildren<MoneySlot>();

        if (moneyManager == null)
        {
            moneyManager = FindObjectOfType<MoneyManager>();
            if (moneyManager == null)
            {
                Debug.LogError("이 씬에 머니매니저가 없음");
            }
        }
    }

    public void OnCreateItemButtonClicked()
    {
        CreateRandomItem();
    }

    public void CreateRandomItem()
    {
        MoneySlot emptySlot = GetEmptyInventorySlot();

        if (emptySlot != null)
        {
            int randomItemIndex = Random.Range(0, itemPrefabs.Count);
            var itemPrefab = itemPrefabs[randomItemIndex];
            var item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            item.GetComponent<Item>().SetItem(1, itemPrefab.name, emptySlot.transform);

            emptySlot.SetItem(item.GetComponent<Item>());
        }
        else
        {
            Debug.LogWarning("빈 슬롯이 없음");
        }
    }

    public void UpgradeExistingItem(Item item, int newNumber)
    {
        string itemType = item.itemName;

        if (newNumber < 4)
        {
            item.SetItem(newNumber, itemType, item.transform.parent);
        }
        else
        {
            Destroy(item.gameObject);
        }

        if (moneyManager != null)
        {
            moneyManager.OnItemMerged(newNumber, itemType);
        }
    }

    MoneySlot GetEmptyInventorySlot()
    {
        foreach (MoneySlot slot in inventorySlots)
        {
            if (slot.item == null)
            {
                return slot;
            }
        }
        return null;
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInventoryManager : MonoBehaviour
{
    public static MoneyInventoryManager inst;
    MoneySlot[] inventorySlots;
    public Transform innerPanelTransform;
    public List<GameObject> itemPrefabs;
    public MoneyManager moneyManager;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        inventorySlots = innerPanelTransform.GetComponentsInChildren<MoneySlot>();

        if (moneyManager == null)
        {
            moneyManager = FindObjectOfType<MoneyManager>();
            if (moneyManager == null)
            {
                Debug.LogError("MoneyManager not found in the scene!");
            }
        }
    }

    public void OnCreateItemButtonClicked()
    {
        CreateRandomItem();
    }

    public void CreateRandomItem()
    {
        MoneySlot emptySlot = GetEmptyInventorySlot();

        if (emptySlot != null)
        {
            int randomItemIndex = Random.Range(0, itemPrefabs.Count);
            var itemPrefab = itemPrefabs[randomItemIndex];
            var item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            item.GetComponent<Item>().SetItem(1, itemPrefab.name, emptySlot.transform);

            emptySlot.SetItem(item.GetComponent<Item>());
        }
        else
        {
            Debug.LogWarning("No empty slots available!");
        }
    }

    public void UpgradeExistingItem(Item item, int newNumber)
    {
        if (newNumber < 4)
        {
            item.SetItem(newNumber, item.itemName, item.transform.parent);
        }
        else
        {
            Destroy(item.gameObject);
        }

        if (moneyManager != null)
        {
            moneyManager.OnItemMerged(newNumber, item.itemName);
        }
    }

    MoneySlot GetEmptyInventorySlot()
    {
        foreach (MoneySlot slot in inventorySlots)
        {
            if (slot.IsEmpty())
            {
                return slot;
            }
        }
        return null;
    }
}
