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
    public static MoneyManager inst;
    private Dictionary<string, int> mergeCounts = new Dictionary<string, int>();
    public Dictionary<string, string> itemScenes = new Dictionary<string, string>();

    public Text MoneyText;
    public int Money = 0;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        mergeCounts.Add("µ·", 0);
        UpdateMoneyUI();
    }

    public void OnItemMerged(int newNumber, string itemType)
    {
        if (newNumber == 4)
        {
            Money += 1000;
            UpdateMoneyUI();

            if (mergeCounts.ContainsKey(itemType))
            {
                mergeCounts[itemType]++;
            }
            else
            {
                Debug.LogWarning("Unknown item type: " + itemType);
            }
        }
    }

    public void SpendMoney(int amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            UpdateMoneyUI();
        }
    }

    void UpdateMoneyUI()
    {
        MoneyText.text = Money + "¿ø";
    }
}
