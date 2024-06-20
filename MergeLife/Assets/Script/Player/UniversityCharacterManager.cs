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

    public Text ���̿÷�Text;
    public Text û����Text;
    public Text ��ǻ��Text;

    public HealthManager healthManager;

    private int currentYear;
    private int currentAge = 20;

    void Start()
    {
        mergeCounts.Add("���̿÷�", 0);
        mergeCounts.Add("û����", 0);
        mergeCounts.Add("��ǻ��", 0);

        itemScenes.Add("���̿÷�", "EndMusicScene");
        itemScenes.Add("û����", "EndDoctorScene");
        itemScenes.Add("��ǻ��", "EndBusinessScene");

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
        return mergeCounts["���̿÷�"] >= 4 && mergeCounts["û����"] >= 4 && mergeCounts["��ǻ��"] >= 4;
    }

    void UpdateUI()
    {
        ���̿÷�Text.text = ": " + mergeCounts["���̿÷�"] + " / 4";
        û����Text.text = ": " + mergeCounts["û����"] + " / 4";
        ��ǻ��Text.text = ": " + mergeCounts["��ǻ��"] + " / 4";
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
