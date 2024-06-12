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

    public Text itemText;
    public Text item2Text;

    void Start()
    {
        mergeCounts.Add("Item", 0);
        mergeCounts.Add("Item2", 0);

        itemScenes.Add("Item", "StudentScene");
        itemScenes.Add("Item2", "MoneyScene");

        UpdateUI();
    }

    public void OnItemMerged(int newNumber, string itemType)
    {
        if (newNumber == 3)
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
        itemText.text = ": " + mergeCounts["Item"];
        item2Text.text = ": " + mergeCounts["Item2"];
    }
}
