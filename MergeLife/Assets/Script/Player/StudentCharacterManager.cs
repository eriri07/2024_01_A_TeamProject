using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class StudentCharacterManager : MonoBehaviour
{
    private Dictionary<string, int> mergeCounts = new Dictionary<string, int>();
    public Dictionary<string, string> itemScenes = new Dictionary<string, string>();

    public Text calendarText;
    private CalendarManager calendarManager;

    public Text 축구공Text;
    public Text 책Text;

    public HealthManager healthManager;

    private int currentYear;
    private int currentAge = 14;

    void Start()
    {
        mergeCounts.Add("축구공", 0);
        mergeCounts.Add("책", 0);

        itemScenes.Add("축구공", "University2Scene");
        itemScenes.Add("책", "UniversityScene");

        DateTime startDate = new DateTime(2018, 3, 19);
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
        if (mergeCounts[itemType] >= 2)
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
        축구공Text.text = ": " + mergeCounts["축구공"] + " / 4";
        책Text.text = ": " + mergeCounts["책"] + " / 4";
    }

    void UpdateCalendarUI()
    {
        DateTime currentDate = calendarManager.GetCurrentDate();
        calendarText.text = currentDate.ToString("yyyy") + "년 " + currentAge + "세";

        if (currentDate.Year > currentYear)
        {
            currentYear = currentDate.Year;
            currentAge++;
            UpdateCalendarUI();
        }
    }
}

