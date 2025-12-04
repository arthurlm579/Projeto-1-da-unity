using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    public GameObject enemy;   // referenciar o inimigo pai
    public float bounceForce = 10f;   // for�a que o player vai quicar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player quica pra cima
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);

            // Destr�i o inimigo
            Destroy(enemy);
        }
    }
}
