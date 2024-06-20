using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Text healthText;

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
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void UpdateHealthUI()
    {
        healthText.text = ": " + currentHealth;
    }
}
