/*using System.Collections;
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
    public List<Button> itemButtons; // 각 아이템의 구매 버튼

    // 각 아이템 패널의 구매 완료 메시지 패널
    public List<GameObject> purchaseCompletePanels;

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

        if (itemButtons.Count != shopItems.Count || purchaseCompletePanels.Count != shopItems.Count)
        {
            Debug.LogError("The number of itemButtons or purchaseCompletePanels does not match the number of shopItems!");
        }

        // 모든 구매 완료 패널을 비활성화
        foreach (var panel in purchaseCompletePanels)
        {
            panel.SetActive(false);
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
                UpdateButtonToPurchased(itemIndex); // 구매 완료 텍스트로 변경
                ShowPurchaseCompletePanel(itemIndex); // 구매 완료 패널 표시
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

    void UpdateButtonToPurchased(int itemIndex)
    {
        if (itemIndex < itemButtons.Count)
        {
            Text buttonText = itemButtons[itemIndex].GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.text = "구매 완료";
            }
            else
            {
                Debug.LogWarning("Button does not have a Text component!");
            }
        }
    }

    void ShowPurchaseCompletePanel(int itemIndex)
    {
        if (itemIndex < purchaseCompletePanels.Count)
        {
            GameObject panel = purchaseCompletePanels[itemIndex];
            if (panel != null)
            {
                panel.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Purchase complete panel is missing!");
            }
        }
    }
}

