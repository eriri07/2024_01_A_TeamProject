/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public MoneyManager moneyManager;
    public InventoryManager inventoryManager;
    public HealthManager healthManager;

    public List<GameObject> shopItems;
    public List<int> itemPrices;
    public int healthPotionIndex; 

    public GameObject purchaseCompletePanelPrefab;
    private GameObject currentPurchaseCompletePanel;

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

        if (healthManager == null)
        {
            healthManager = FindObjectOfType<HealthManager>();
            if (healthManager == null)
            {
                Debug.LogError("HealthManager not found in the scene!");
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

                if (itemIndex == healthPotionIndex) 
                {
                    healthManager.IncreaseHealth(30);
                }

                Debug.Log("Item bought: " + shopItems[itemIndex].name);

                ShowPurchaseCompletePanel(shopItems[itemIndex].name);

                SoundManager.instance.PlaySound("Cash");
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

    void ShowPurchaseCompletePanel(string itemName)
    {
        if (purchaseCompletePanelPrefab != null)
        {
            if (currentPurchaseCompletePanel != null)
            {
                Destroy(currentPurchaseCompletePanel);
            }
            currentPurchaseCompletePanel = Instantiate(purchaseCompletePanelPrefab, transform);

            Text[] panelTexts = currentPurchaseCompletePanel.GetComponentsInChildren<Text>();
            foreach (Text text in panelTexts)
            {
                if (text.name == "PurchaseCompleteText")
                {
                    text.text = itemName + " purchased successfully!";
                    break;
                }
            }

            Destroy(currentPurchaseCompletePanel, 2f);
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
    public List<Button> itemButtons; 

    public List<GameObject> purchaseCompletePanels;

    public HealthManager healthManager;

    public int healthPotionIndex;

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
                UpdateButtonToPurchased(itemIndex); 
                ShowPurchaseCompletePanel(itemIndex);

                SoundManager.instance.PlaySound("Cash");

                if (itemIndex == healthPotionIndex) 
                {
                    healthManager.IncreaseHealth(30);
                }
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

    void HidePurchaseCompletePanel(int itemIndex)
    {
        if (itemIndex < purchaseCompletePanels.Count)
        {
            GameObject panel = purchaseCompletePanels[itemIndex];
            if (panel != null)
            {
                panel.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Purchase complete panel is missing!");
            }
        }
    }
}
