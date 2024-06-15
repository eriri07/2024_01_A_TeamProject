using System.Collections;
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
