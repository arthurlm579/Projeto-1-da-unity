using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;
    public float bounceForce = 10f;

    public void DamagePlayer(GameObject player)
    {
        var ph = player.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.TakeDamage(damage);
        }
    }

    public void KillEnemy(GameObject player)
    {
        // faz o player quicar ao matar o inimigo
        var rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
        }

        Destroy(gameObject);
    }
}
