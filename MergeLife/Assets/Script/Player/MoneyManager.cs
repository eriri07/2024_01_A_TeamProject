using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    private int mergeCount = 0; 

    public Text text;
    int score = 0;

    public void OnItemMerged(int newNumber)
    {
        if (newNumber == 2)
        {
            mergeCount++;
            score += 1;

            SetText();
        }
    }


    public void SetText()
    {
        text.text = ": " + score.ToString();
    }

}