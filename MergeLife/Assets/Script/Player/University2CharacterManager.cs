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

    public Text ����Text;
    public Text �߱���Text;

    public HealthManager healthManager;

    private int currentYear;
    private int currentAge = 20;

    void Start()
    {

        mergeCounts.Add("����", 0);
        mergeCounts.Add("�߱���", 0);

        itemScenes.Add("����", "EndPoliceScene");
        itemScenes.Add("�߱���", "EndBaseballScene");

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
        ����Text.text = ": " + mergeCounts["����"] + " / 4";
        �߱���Text.text = ": " + mergeCounts["�߱���"] + " / 4";
    }

    void UpdateCalendarUI()
    {
        DateTime currentDate = calendarManager.GetCurrentDate();
        calendarText.text = currentDate.ToString("yyyy") + "�� " + currentAge + "��";

        if (currentDate.Year > currentYear)
        {
            currentYear = currentDate.Year;
            currentAge++;
            UpdateCalendarUI();
        }
    }
}

