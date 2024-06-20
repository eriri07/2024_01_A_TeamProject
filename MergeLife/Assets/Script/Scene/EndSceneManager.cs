/*using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public Image endingImage;
    public Text endingText;
    public Button retryButton;
    public Button mainMenuButton;

    public string fullText = "����� ������ �������ϴ�.\n�����ϼ̽��ϴ�!"; 
    public float fadeDuration = 2.0f;
    public float textDisplaySpeed = 0.1f; 
    public float delayBeforeButtons = 3.0f; 

    void Start()
    {
        fadeCanvasGroup.alpha = 0;
        endingImage.enabled = false;
        endingText.text = "";
        retryButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        StartCoroutine(FadeToWhiteAndShowEnding());

        SoundManager.instance.PlaySound("End");
    }

    private IEnumerator FadeToWhiteAndShowEnding()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }

        endingImage.enabled = true;
        yield return StartCoroutine(DisplayText());

        yield return new WaitForSeconds(delayBeforeButtons);

        retryButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    private IEnumerator DisplayText()
    {
        foreach (char letter in fullText)
        {
            endingText.text += letter;
            yield return new WaitForSeconds(textDisplaySpeed);
        }
    }

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainScene"); 
    }
}
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public Image endingImage;
    public Text endingText;
    public Button retryButton;
    public Button mainMenuButton;

    public string fullText = "����� ������ �������ϴ�.\n�����ϼ̽��ϴ�!";
    public float fadeDuration = 2.0f;
    public float textDisplaySpeed = 0.1f;
    public float delayBeforeButtons = 3.0f;

    // ���� ID (�� �������� �����ϰ� ����)
    public int endingID;

    void Start()
    {
        fadeCanvasGroup.alpha = 0;
        endingImage.enabled = false;
        endingText.text = "";
        retryButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        StartCoroutine(FadeToWhiteAndShowEnding());

        SoundManager.instance.PlaySound("End");
    }

    private IEnumerator FadeToWhiteAndShowEnding()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Clamp01(elapsed / fadeDuration);
            yield return null;
        }

        endingImage.enabled = true;
        yield return StartCoroutine(DisplayText());

        yield return new WaitForSeconds(delayBeforeButtons);

        UnlockEnding(); // ���� �ر� ���� ����

        retryButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    private IEnumerator DisplayText()
    {
        foreach (char letter in fullText)
        {
            endingText.text += letter;
            yield return new WaitForSeconds(textDisplaySpeed);
        }
    }

    private void UnlockEnding()
    {
        PlayerPrefs.SetInt("EndingUnlocked_" + endingID, 1);
        PlayerPrefs.Save();
    }

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("BabyScene");
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
}
