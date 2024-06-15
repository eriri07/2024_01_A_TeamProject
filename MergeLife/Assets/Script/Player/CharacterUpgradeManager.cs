using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterUpgradeManager : MonoBehaviour
{
    private Dictionary<string, int> mergeCounts = new Dictionary<string, int>();
    public Dictionary<string, string> itemScenes = new Dictionary<string, string>();

    public Text ScoreText;
    private int Score = 0;

    public Text �߱���Text;
    public Text ���̿ø�Text;
    public Text ����Text;
    public Text û����Text;

    void Start()
    {
        mergeCounts.Add("�߱���", 0);
        mergeCounts.Add("���̿ø�", 0);
        mergeCounts.Add("����", 0);
        mergeCounts.Add("û����", 0);

        itemScenes.Add("�߱���", "BaseballScene");
        itemScenes.Add("���̿ø�", "ViolinScene");
        itemScenes.Add("����", "PoliceScene");
        itemScenes.Add("û����", "DoctorScene");

        UpdateUI();
    }

    public void OnItemMerged(int newNumber, string itemType)
    {
        if (newNumber == 4)
        {
            if (mergeCounts.ContainsKey(itemType))
            {
                mergeCounts[itemType]++;
                Score += 1;

                UpdateUI();
                CheckMergeCount(itemType);
            }
            else
            {
                Debug.LogWarning("Unknown item type: " + itemType);
            }
        }
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
        �߱���Text.text = ": " + mergeCounts["�߱���"] + " / 4";
        ���̿ø�Text.text = ": " + mergeCounts["���̿ø�"] + " / 4";
        ����Text.text = ": " + mergeCounts["����"] + " / 4";
        û����Text.text = ": " + mergeCounts["û����"] + " / 4";
    }
}
