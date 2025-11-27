using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    public GameObject enemy;
    public float bounceForce = 8f;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);

            Destroy(enemy);
        }
    }
}
