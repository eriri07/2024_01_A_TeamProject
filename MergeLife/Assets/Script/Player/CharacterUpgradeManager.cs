using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterUpgradeManager : MonoBehaviour
{
    private int mergeCount = 0; 
    public string nextSceneName;

    public Text text;
    int score = 0;

    public void OnItemMerged(int newNumber)
    {
        if (newNumber == 4)
        {
            mergeCount++;
            score += 1;

            SetText();
            CheckMergeCount();
        }
    }

    void CheckMergeCount()
    {
        if (mergeCount >= 2)
        {
            LoadNextScene();
        }
    }

    public void SetText()
    {
        text.text = ": " + score.ToString();
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene("StudentScene"); 
        }

    }
}