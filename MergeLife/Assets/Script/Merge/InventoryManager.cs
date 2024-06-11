/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inst;
    Slot[] inventorySlots;
    public Transform innerPanelTransform;
    public GameObject itemPrefab;
    public CharacterUpgradeManager characterUpgradeManager;

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

        if (characterUpgradeManager != null)
        {
            characterUpgradeManager.OnItemMerged(newNumber);
        }
    }
}

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inst;
    Slot[] inventorySlots;
    public Transform innerPanelTransform;

    // 여러 아이템 프리팹을 관리하는 리스트
    public List<GameObject> itemPrefabs;

    public CharacterUpgradeManager characterUpgradeManager; // 캐릭터 업그레이드 매니저 참조

    // Start is called before the first frame update
    void Start()
    {
        inst = this;
        inventorySlots = innerPanelTransform.GetComponentsInChildren<Slot>();

        // CharacterUpgradeManager 자동 참조
        if (characterUpgradeManager == null)
        {
            characterUpgradeManager = FindObjectOfType<CharacterUpgradeManager>();
            if (characterUpgradeManager == null)
            {
                Debug.LogError("CharacterUpgradeManager not found in the scene!");
            }
        }
    }

    // 아이템 생성 버튼 클릭 시 호출되는 메서드
    public void OnCreateItemButtonClicked()
    {
        CreateRandomItem();
    }

    public void CreateRandomItem()
    {
        Slot emptySlot = GetEmptyInventorySlot();

        if (emptySlot != null)
        {
            int randomItemIndex = Random.Range(0, itemPrefabs.Count); // 랜덤 아이템 선택
            var itemPrefab = itemPrefabs[randomItemIndex];
            var item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            item.GetComponent<Item>().SetItem(1, itemPrefab.name, emptySlot.transform); // 아이템 유형 설정

            // 슬롯에 아이템을 설정
            emptySlot.SetItem(item.GetComponent<Item>());
        }
        else
        {
            Debug.LogWarning("No empty slots available!");
        }
    }

    public void UpgradeExistingItem(Item item, int newNumber)
    {
        item.SetItem(newNumber, item.itemType, item.transform.parent); // 아이템 유형 유지
        // 캐릭터 업그레이드 매니저에 통보
        if (characterUpgradeManager != null)
        {
            Debug.Log($"Item upgraded to number: {newNumber}");
            characterUpgradeManager.OnItemMerged(newNumber); // 캐릭터 업그레이드 매니저에 머지된 아이템 정보 전달
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


