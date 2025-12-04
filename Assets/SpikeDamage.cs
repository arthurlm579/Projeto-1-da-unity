using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();

            // Mata instantaneamente
            health.TakeDamage(health.maxHealth);
        }
    }
}
