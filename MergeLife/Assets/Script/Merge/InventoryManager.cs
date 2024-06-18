/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inst;
    Slot[] inventorySlots;
    public Transform innerPanelTransform;

    public List<GameObject> itemPrefabs;

    public CharacterUpgradeManager characterUpgradeManager;

    void Start()
    {
        inst = this;
        inventorySlots = innerPanelTransform.GetComponentsInChildren<Slot>();

        if (characterUpgradeManager == null)
        {
            characterUpgradeManager = FindObjectOfType<CharacterUpgradeManager>();
            if (characterUpgradeManager == null)
            {
                Debug.LogError("CharacterUpgradeManager not found in the scene!");
            }
        }
    }

    public void OnCreateItemButtonClicked()
    {
        CreateRandomItem();
    }

    public void CreateRandomItem()
    {
        Slot emptySlot = GetEmptyInventorySlot();

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
        string itemType = item.itemType;

        if (newNumber < 4)
        {
            item.SetItem(newNumber, itemType, item.transform.parent);
        }
        else
        {
            Destroy(item.gameObject);
        }

        if (characterUpgradeManager != null)
        {
            characterUpgradeManager.OnItemMerged(newNumber, itemType);
        }
    }

    Slot GetEmptyInventorySlot()
    {
        foreach (Slot slot in inventorySlots)
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
