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
            Debug.LogWarning("���� �����մϴ�.");
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
                Debug.LogError("�� ���� �ӴϸŴ����� ����");
            }
        }

        if (inventoryManager == null)
        {
            inventoryManager = InventoryManager.instance;
            if (inventoryManager == null)
            {
                Debug.LogError("�� ���� �κ��丮�Ŵ����� ����");
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
                Debug.LogWarning("���� ������");
            }
        }
        else
        {
            Debug.LogWarning("�߸��� ������ �ε���");
        }
    }
}
