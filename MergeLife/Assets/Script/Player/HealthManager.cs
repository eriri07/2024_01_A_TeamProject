using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Text healthText;

    public GameOverManager gameOverManager;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthUI();

        if (currentHealth == 0)
        {
            gameOverManager.StartGameOverSequence();
        }
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = ": " + currentHealth;
        }
    }
}
