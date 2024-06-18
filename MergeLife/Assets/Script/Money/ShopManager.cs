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
            moneyManager = MoneyManager.instance;
            if (moneyManager == null)
            {
                Debug.LogError("MoneyManager not found in the scene!");
            }
        }

        if (inventoryManager == null)
        {
            inventoryManager = InventoryManager.instance;
            if (inventoryManager == null)
            {
                Debug.LogError("InventoryManager not found in the scene!");
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
                inventoryManager.PurchaseItem(shopItems[itemIndex].name, price);
                Debug.Log("Item bought: " + shopItems[itemIndex].name);
            }
            else
            {
                Debug.LogWarning("Not enough money");
            }
        }
        else
        {
            Debug.LogWarning("Invalid item index");
        }
    }
}

