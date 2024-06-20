using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class University2CharacterManager : MonoBehaviour
{
    private Dictionary<string, int> mergeCounts = new Dictionary<string, int>();
    public Dictionary<string, string> itemScenes = new Dictionary<string, string>();

    public Text calendarText;
    private CalendarManager calendarManager;

    public Text 荐癌Text;
    public Text 具备傍Text;

    public HealthManager healthManager;

    private int currentYear;
    private int currentAge = 20;

    void Start()
    {

        mergeCounts.Add("荐癌", 0);
        mergeCounts.Add("具备傍", 0);

        itemScenes.Add("荐癌", "EndPoliceScene");
        itemScenes.Add("具备傍", "EndBaseballScene");

        DateTime startDate = new DateTime(2024, 3, 19);
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
        荐癌Text.text = ": " + mergeCounts["荐癌"] + " / 4";
        具备傍Text.text = ": " + mergeCounts["具备傍"] + " / 4";
    }

    void UpdateCalendarUI()
    {
        DateTime currentDate = calendarManager.GetCurrentDate();
        calendarText.text = currentDate.ToString("yyyy") + "斥 " + currentAge + "技";

        if (currentDate.Year > currentYear)
        {
            currentYear = currentDate.Year;
            currentAge++;
            UpdateCalendarUI();
        }
    }
}

