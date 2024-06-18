/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    InventorySlot[] inventorySlots;
    public Transform itemsParent;
    public List<GameObject> itemPrefabs;

    private List<string> purchasedItems = new List<string>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void OnCreateItemButtonClicked()
    {
        CreateRandomItem();
    }

    public void CreateRandomItem()
    {
        InventorySlot emptySlot = GetEmptyInventorySlot();

        if (emptySlot != null && purchasedItems.Count > 0)
        {
            int randomIndex = Random.Range(0, purchasedItems.Count);
            string itemName = purchasedItems[randomIndex];
            GameObject itemPrefab = itemPrefabs.Find(item => item.name == itemName);

            if (itemPrefab != null)
            {
                GameObject newItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
                newItem.GetComponent<Item>().SetItem(1, itemName, emptySlot.transform);
                emptySlot.SetItem(newItem.GetComponent<Item>());
            }
        }
        else
        {
            Debug.LogWarning("빈 슬롯이 없거나 구매된 아이템이 없습니다.");
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
    }

    InventorySlot GetEmptyInventorySlot()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.IsEmpty())
            {
                return slot;
            }
        }
        return null;
    }

    public void PurchaseItem(string itemName)
    {
        if (!purchasedItems.Contains(itemName))
        {
            purchasedItems.Add(itemName);
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    InventorySlot[] inventorySlots;
    public Transform itemsParent;
    public List<GameObject> itemPrefabs;

    private List<string> purchasedItems = new List<string>();

    public MoneyManager moneyManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();

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
        InventorySlot emptySlot = GetEmptyInventorySlot();

        if (emptySlot != null && purchasedItems.Count > 0)
        {
            int randomIndex = Random.Range(0, purchasedItems.Count);
            string itemName = purchasedItems[randomIndex];
            GameObject itemPrefab = itemPrefabs.Find(item => item.name == itemName);

            if (itemPrefab != null)
            {
                GameObject newItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
                newItem.GetComponent<Item>().SetItem(1, itemName, emptySlot.transform);
                emptySlot.SetItem(newItem.GetComponent<Item>());
                Debug.Log("아이템 생성됨: " + itemName); 
            }
            else
            {
                Debug.LogWarning("아이템 프리팹을 찾을 수 없음: " + itemName); 
            }
        }
        else
        {
            Debug.LogWarning("빈 슬롯이 없거나 구매된 아이템이 없습니다.");
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
    }

    InventorySlot GetEmptyInventorySlot()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.IsEmpty())
            {
                Debug.Log("빈 슬롯 발견: " + slot.name); 
                return slot;
            }
        }
        Debug.LogWarning("빈 슬롯을 찾을 수 없음"); 
        return null;
    }

    public void PurchaseItem(string itemName, int itemCost)
    {
        if (moneyManager.Money >= itemCost)
        {
            moneyManager.Money -= itemCost;
            moneyManager.UpdateMoneyText();

            if (!purchasedItems.Contains(itemName))
            {
                purchasedItems.Add(itemName);
                Debug.Log("아이템 구매됨: " + itemName);
            }
        }
        else
        {
            Debug.LogWarning("돈이 부족합니다.");
        }
    }
}

