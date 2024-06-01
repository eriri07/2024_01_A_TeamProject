using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMager : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("BabyScene");
    }

    public void GameSetting()
    {
        SceneManager.LoadScene("GameSetting");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void MoneyScene()
    {
        SceneManager.LoadScene("MoneyScene");
    }

    public void BabyScene()
    {
        SceneManager.LoadScene("BabyScene");
    }

    public void ShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }
}