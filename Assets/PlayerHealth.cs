using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthBar;
    public GameObject deathScreen;

    private PlayerRespawn respawnSystem;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        deathScreen.SetActive(false);

        respawnSystem = GetComponent<PlayerRespawn>();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0)
            currentHealth = 0;

        healthBar.value = currentHealth;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }

    public void Retry()
    {
        // "Revive" sem reiniciar a cena
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        healthBar.value = maxHealth;

        deathScreen.SetActive(false);

        // Volta ao checkpoint
        respawnSystem.RespawnPlayer();
    }

    public void Menu()
    {
        // Aqui sim troca de cena
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
