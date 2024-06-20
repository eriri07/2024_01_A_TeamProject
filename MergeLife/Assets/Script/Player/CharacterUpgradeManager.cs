using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterUpgradeManager : MonoBehaviour
{
    private Dictionary<string, int> mergeCounts = new Dictionary<string, int>();
    public Dictionary<string, string> itemScenes = new Dictionary<string, string>();

    public Text calendarText;
    private CalendarManager calendarManager;

    public Text item1Text;
    public Text item2Text;
    public Text item3Text;
    public Text item4Text;

    public HealthManager healthManager;

    private int currentYear;
    private int currentAge = 1; 

    void Start()
    {
        mergeCounts.Add("item1", 0);
        mergeCounts.Add("item2", 0);
        mergeCounts.Add("item3", 0);
        mergeCounts.Add("item4", 0);

        itemScenes.Add("item1", "KidScene");
        itemScenes.Add("item2", "KidScene");
        itemScenes.Add("item3", "PoliceScene");
        itemScenes.Add("item4", "DoctorScene");

        DateTime startDate = new DateTime(2005, 1, 19);
        calendarManager = new CalendarManager(startDate);

        currentYear = startDate.Year;

        UpdateUI();
        UpdateCalendarUI();
    }

    public void OnItemMerged(int newNumber, string itemType)
    {
        if (newNumber == 4)
        {
            if (mergeCounts.ContainsKey(itemType))
            {
                mergeCounts[itemType]++;
                UpdateUI();
                CheckMergeCount(itemType);
            }
            else
            {
                Debug.LogWarning("Unknown item type: " + itemType);
            }
        }

        healthManager.DecreaseHealth(5);

        calendarManager.AdvanceThreeMonths();
        UpdateCalendarUI();
    }

    void CheckMergeCount(string itemType)
    {
        if (mergeCounts[itemType] >= 4)
        {
            LoadNextScene(itemType);
        }
    }

    void LoadNextScene(string itemType)
    {
        if (itemScenes.ContainsKey(itemType))
        {
            string nextSceneName = itemScenes[itemType];
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
        else
        {
            Debug.LogWarning("No scene defined for item type: " + itemType);
        }
    }

    void UpdateUI()
    {
        item1Text.text = ": " + mergeCounts["item1"] + " / 4";
        item2Text.text = ": " + mergeCounts["item2"] + " / 4";
        item3Text.text = ": " + mergeCounts["item3"] + " / 4";
        item4Text.text = ": " + mergeCounts["item4"] + " / 4";
    }

    void UpdateCalendarUI()
    {
        DateTime currentDate = calendarManager.GetCurrentDate();
        calendarText.text = currentDate.ToString("yyyy") + "³â " + currentAge + "¼¼";

        if (currentDate.Year > currentYear)
        {
            currentYear = currentDate.Year;
            currentAge++;
            UpdateCalendarUI(); 
        }
    }
}

