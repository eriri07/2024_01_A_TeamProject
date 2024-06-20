using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UniversityCharacterManager : MonoBehaviour
{
    private Dictionary<string, int> mergeCounts = new Dictionary<string, int>();
    public Dictionary<string, string> itemScenes = new Dictionary<string, string>();

    public Text calendarText;
    private CalendarManager calendarManager;

    public Text 바이올렛Text;
    public Text 청진기Text;
    public Text 컴퓨터Text;

    public HealthManager healthManager;

    private int currentYear;
    private int currentAge = 20;

    void Start()
    {
        mergeCounts.Add("바이올렛", 0);
        mergeCounts.Add("청진기", 0);
        mergeCounts.Add("컴퓨터", 0);

        itemScenes.Add("바이올렛", "EndMusicScene");
        itemScenes.Add("청진기", "EndDoctorScene");
        itemScenes.Add("컴퓨터", "EndBusinessScene");

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
                if (IsEndingConditionMet())
                {
                    SceneManager.LoadScene("EndScene");
                }
                else
                {
                    SceneManager.LoadScene(nextSceneName);
                }
            }
        }
        else
        {
            Debug.LogWarning("No scene defined for item type: " + itemType);
        }
    }

    bool IsEndingConditionMet()
    {
        return mergeCounts["바이올렛"] >= 4 && mergeCounts["청진기"] >= 4 && mergeCounts["컴퓨터"] >= 4;
    }

    void UpdateUI()
    {
        바이올렛Text.text = ": " + mergeCounts["바이올렛"] + " / 4";
        청진기Text.text = ": " + mergeCounts["청진기"] + " / 4";
        컴퓨터Text.text = ": " + mergeCounts["컴퓨터"] + " / 4";
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
