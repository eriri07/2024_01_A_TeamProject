using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterUpgradeManager : MonoBehaviour
{
    private int mergeCount = 0; 
    public string nextSceneName; 

    public void OnItemMerged(int newNumber)
    {
        if (newNumber == 2)
        {
            mergeCount++;
            CheckMergeCount();
        }
    }

    void CheckMergeCount()
    {
        if (mergeCount >= 1)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene("StudentScene"); 
        }

    }
}