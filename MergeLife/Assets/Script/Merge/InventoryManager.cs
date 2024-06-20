using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    InventorySlot[] inventorySlots;
    public Transform itemsParent;
    public List<GameObject> itemPrefabs;

    private List<string> purchasedItems = new List<string>();

    public BabyCharacterManager babyCharacterManager;
    public KidCharacterManager kidCharacterManager;
    public StudentCharacterManager studentCharacterManager;
    public UniversityCharacterManager universityCharacterManager;
    public University2CharacterManager university2CharacterManager;
    public CharacterUpgradeManager characterUpgradeManager;

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
        if (characterUpgradeManager == null)
        {
            characterUpgradeManager = FindObjectOfType<CharacterUpgradeManager>();
            babyCharacterManager = FindObjectOfType<BabyCharacterManager>();
            kidCharacterManager = FindObjectOfType<KidCharacterManager>();
            studentCharacterManager = FindObjectOfType<StudentCharacterManager>();
            universityCharacterManager = FindObjectOfType<UniversityCharacterManager>();
            university2CharacterManager = FindObjectOfType<University2CharacterManager>();

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

                SoundManager.instance.PlaySound("Spawn");
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

        if (characterUpgradeManager != null)
        {
            characterUpgradeManager.OnItemMerged(newNumber, item.itemName);
        }

        if (babyCharacterManager != null)
        {
            babyCharacterManager.OnItemMerged(newNumber, item.itemName);
        }

        if (kidCharacterManager != null)
        {
            kidCharacterManager.OnItemMerged(newNumber, item.itemName);
        }

        if (studentCharacterManager != null)
        {
            studentCharacterManager.OnItemMerged(newNumber, item.itemName);
        }

        if (universityCharacterManager != null)
        {
            universityCharacterManager.OnItemMerged(newNumber, item.itemName);
        }

        if (university2CharacterManager != null)
        {
            university2CharacterManager.OnItemMerged(newNumber, item.itemName);
        }

        SoundManager.instance.PlaySound("Drop");

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

    public void PurchaseItem(string itemName, int price)
    {
        if (!purchasedItems.Contains(itemName))
        {
            purchasedItems.Add(itemName);
        }
    }
}
