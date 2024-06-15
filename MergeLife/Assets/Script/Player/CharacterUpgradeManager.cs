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

    public Text 야구공Text;
    public Text 바이올린Text;
    public Text 수갑Text;
    public Text 청진기Text;

    void Start()
    {
        mergeCounts.Add("야구공", 0);
        mergeCounts.Add("바이올린", 0);
        mergeCounts.Add("수갑", 0);
        mergeCounts.Add("청진기", 0);

        itemScenes.Add("야구공", "BaseballScene");
        itemScenes.Add("바이올린", "ViolinScene");
        itemScenes.Add("수갑", "PoliceScene");
        itemScenes.Add("청진기", "DoctorScene");

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
        야구공Text.text = ": " + mergeCounts["야구공"] + " / 4";
        바이올린Text.text = ": " + mergeCounts["바이올린"] + " / 4";
        수갑Text.text = ": " + mergeCounts["수갑"] + " / 4";
        청진기Text.text = ": " + mergeCounts["청진기"] + " / 4";
    }
}
