using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject babyScene;
    public GameObject moneyScene;
    public GameObject pauseCanvas;
    public GameObject shopCanvas;
    public GameObject GalleryCanvas;
    public GameObject settingCanvas;



    public void GameStart()
    {
        SceneManager.LoadScene("BabyScene");
    }

    public void GameSetting()
    {
        settingCanvas.SetActive(true);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void MoneyScene()
    {
        moneyScene.SetActive(true);
        babyScene.SetActive(false);
    }

    public void BabyScene()
    {
        babyScene.SetActive(true);
        moneyScene.SetActive(false);
    }

    public void ShopPanel()
    {
        shopCanvas.SetActive(true);
        pauseCanvas.SetActive(false);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        shopCanvas.SetActive(false);
        pauseCanvas.SetActive(true);

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void OnGallery()
    {
        GalleryCanvas.SetActive(true);
    }

    public void OffGallery()
    {
        GalleryCanvas.SetActive(false);
    }

    public void OffSetting()
    {
        settingCanvas.SetActive(false);
    }

    public void ReStart()
    {
        SceneManager.LoadScene("BabyScene");
    }
}