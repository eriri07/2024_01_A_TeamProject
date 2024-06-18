/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public List<string> itemsForSale;
    public InventoryManager inventoryManager;
    public MoneyManager moneyManager;
    public int itemCost = 100;

    void Start()
    {
        if (inventoryManager == null)
        {
            inventoryManager = InventoryManager.instance;
        }
        if (moneyManager == null)
        {
            moneyManager = FindObjectOfType<MoneyManager>();
        }
    }

    public void PurchaseItem(string itemName)
    {
        if (moneyManager.Money >= itemCost)
        {
            moneyManager.Money -= itemCost;
            inventoryManager.PurchaseItem(itemName);
        }
        else
        {
            Debug.LogWarning("돈이 부족합니다.");
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public MoneyManager moneyManager;
    public InventoryManager inventoryManager;
    public List<GameObject> shopItems;
    public List<int> itemPrices;

    void Start()
    {
        if (moneyManager == null)
        {
            moneyManager = MoneyManager.inst;
            if (moneyManager == null)
            {
                Debug.LogError("이 씬에 머니매니저가 없음");
            }
        }

        if (inventoryManager == null)
        {
            inventoryManager = InventoryManager.instance;
            if (inventoryManager == null)
            {
                Debug.LogError("이 씬에 인벤토리매니저가 없음");
            }
        }
    }

    public void BuyItem(int itemIndex)
    {
        if (itemIndex < shopItems.Count && itemIndex < itemPrices.Count)
        {
            int price = itemPrices[itemIndex];
            if (moneyManager.Money >= price)
            {
                moneyManager.SpendMoney(price);
                inventoryManager.itemPrefabs.Add(shopItems[itemIndex]);
            }
            else
            {
                Debug.LogWarning("돈이 부족함");
            }
        }
        else
        {
            Debug.LogWarning("잘못된 아이템 인덱스");
        }
    }
}
