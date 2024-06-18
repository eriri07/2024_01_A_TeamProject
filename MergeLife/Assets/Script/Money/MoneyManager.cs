/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    private Dictionary<string, int> mergeCounts = new Dictionary<string, int>();
    public Dictionary<string, string> itemScenes = new Dictionary<string, string>();

    public Text ScoreText;
    private int Score = 0;

    public Text MoneyText;
    public int Money = 0;

    void Start()
    {
        mergeCounts.Add("µ·", 0);
    }

    public void OnItemMerged(int newNumber, string itemType)
    {

        if (newNumber == 4)
        {
            Money += 1000;
            MoneyText.text = Money + "¿ø";

            if (mergeCounts.ContainsKey(itemType))
            {
                mergeCounts[itemType]++;
                Score += 1;
            }
            else
            {
                Debug.LogWarning("Unknown item type: " + itemType);
            }
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public Text moneyText;
    public int money = 0;

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
        UpdateMoneyText();
    }

    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            UpdateMoneyText();
        }
    }

    public void SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            UpdateMoneyText();
        }
        else
        {
            Debug.LogWarning("Not enough money!");
        }
    }

    public void EarnMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        moneyText.text = money + "¿ø";
    }

    public void OnItemMerged(int newNumber, string itemType)
    {
        if (newNumber == 4)
        {
            EarnMoney(1000);
        }
    }
}
