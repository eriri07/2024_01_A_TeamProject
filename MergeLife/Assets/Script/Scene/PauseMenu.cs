using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ToSettingMenu()
    {
        Debug.Log("���� �̱����Դϴ�...");
    }

    public void ToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("���� �̱����Դϴ�...");
        Application.Quit();
    }
}
