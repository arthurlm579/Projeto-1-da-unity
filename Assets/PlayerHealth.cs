using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Slider healthBar;

    private PlayerRespawn respawn;

    void Start()
    {
        respawn = GetComponent<PlayerRespawn>();

        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth < 0)
            currentHealth = 0;

        healthBar.value = currentHealth;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("PLAYER MORREU");

        // Desativa o jogador
        gameObject.SetActive(false);

        // Chama respawn depois de 1 segundo
        Invoke("RespawnPlayer", 1f);
    }

    void RespawnPlayer()
    {
        // Reativa o jogador
        gameObject.SetActive(true);

        // Teleporta para o checkpoint salvo
        respawn.Respawn();

        // Restaura a vida
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
    }
}
