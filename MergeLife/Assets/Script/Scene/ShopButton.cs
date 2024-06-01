using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject ShopCanvas;

    public void ShopPanel()
    {
        ShopCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        ShopCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
