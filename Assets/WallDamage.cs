using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Charge Attack")]
    public float chargeSpeed = 12f;
    public float chargeCooldown = 2f;
    public float chargeRange = 8f;
    private bool canCharge = true;

    [Header("Knockback e Stun")]
    public float knockbackForce = 14f;
    public float stunTime = 1f;
    private bool isStunned = false;

    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // impede virar
        currentHealth = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isStunned) return;

        // Só ataca se o player estiver perto
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= chargeRange && canCharge)
        {
            StartCoroutine(DoCharge());
        }
    }

    IEnumerator DoCharge()
    {
        canCharge = false;

        // calcula direção apenas horizontal
        float dir = Mathf.Sign(player.position.x - transform.position.x);

        rb.linearVelocity = new Vector2(dir * chargeSpeed, 0);

        yield return new WaitForSeconds(0.4f);

        rb.linearVelocity = Vector2.zero; // para após o dash

        yield return new WaitForSeconds(chargeCooldown);
        canCharge = true;
    }

    // Dano e knockback ao bater na parede
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            TakeDamage();
            ApplyKnockback(collision);
            StartCoroutine(StunBoss());
        }
    }

    void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ApplyKnockback(Collision2D collision)
    {
        Vector2 direction = (transform.position - collision.transform.position).normalized;

        // remove velocidade antes do knockback
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }

    IEnumerator StunBoss()
    {
        isStunned = true;
        rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(stunTime);

        isStunned = false;
    }
}
