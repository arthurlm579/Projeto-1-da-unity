using UnityEngine;
using System.Collections;

public class BossDamageOnWall : MonoBehaviour
{
    public int damage = 10;

    private BossHealth bossHealth;
    private Rigidbody2D rb;

    private void Start()
    {
        bossHealth = GetComponent<BossHealth>();
        rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator Knockback()
    {
        float knockTime = 0.08f;   // duração do efeito
        float timer = 0f;

        float dir = -Mathf.Sign(rb.linearVelocity.x);

        // se estiver parado, empurra pra esquerda
        if (dir == 0)
            dir = -1;

        while (timer < knockTime)
        {
            // força forte do knockback (0.45)
            rb.MovePosition(rb.position + new Vector2(dir * 0.45f, 0));

            timer += Time.deltaTime;
            yield return null;
        }
    }

    private void ApplyDamage()
    {
        bossHealth.TakeDamage(damage);
        StartCoroutine(Knockback());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            ApplyDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            ApplyDamage();
        }
    }
}
