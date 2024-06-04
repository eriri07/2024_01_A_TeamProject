using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject ShopCanvas;
    public GameObject PauseCanvas;

    public void ShopPanel()
    {
        ShopCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        ShopCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
