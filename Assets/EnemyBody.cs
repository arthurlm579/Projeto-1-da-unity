using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            col.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
