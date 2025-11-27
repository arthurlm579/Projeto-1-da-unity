using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public HealthBar healthBar;      // Referência da barra de vida
    public GameOverManager gameOver; // Referência da tela de game over

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            gameOver.ShowGameOver();
        }
    }
}
