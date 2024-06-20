using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public CanvasGroup gameOverCanvasGroup;
    public Text gameOverText;

    private bool isGameOver = false;
    private float fadeDuration = 2.0f;

    void Start()
    {
        gameOverCanvasGroup.alpha = 0;
        gameOverCanvasGroup.interactable = false;
        gameOverCanvasGroup.blocksRaycasts = false;
    }

    public void StartGameOverSequence()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            StartCoroutine(FadeToBlack());
        }

        SoundManager.instance.PlaySound("GameOver");
    }

    private IEnumerator FadeToBlack()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            gameOverCanvasGroup.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }

        ShowGameOverUI();
    }

    private void ShowGameOverUI()
    {
        gameOverCanvasGroup.interactable = true;
        gameOverCanvasGroup.blocksRaycasts = true;
    }

    private void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
