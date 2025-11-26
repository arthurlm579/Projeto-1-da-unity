using UnityEngine;

public class BossChargeAttack : MonoBehaviour
{
    public float detectionRange = 8f;     // Distância para detectar o player
    public float chargeSpeed = 12f;       // Velocidade da investida
    public float chargeDuration = 0.4f;   // Tempo de cada investida
    public float timeBetweenCharges = 1f; // Tempo entre investidas

    private Transform player;
    private Rigidbody2D rb;
    private bool isCharging = false;
    private bool playerNearby = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Se o player estiver perto, ativa loop de investidas
        if (distance <= detectionRange)
        {
            if (!playerNearby)
            {
                playerNearby = true;
                StartCoroutine(ChargeLoop());
            }
        }
        else
        {
            playerNearby = false;
        }
    }

    System.Collections.IEnumerator ChargeLoop()
    {
        while (playerNearby)
        {
            yield return new WaitForSeconds(timeBetweenCharges);

            StartCoroutine(Charge());
        }
    }

    System.Collections.IEnumerator Charge()
    {
        isCharging = true;

        // Direção APENAS HORIZONTAL (sem mover para cima)
        float direction = Mathf.Sign(player.position.x - transform.position.x);

        float timer = 0;

        while (timer < chargeDuration)
        {
            // Movimento somente no eixo X
            rb.linearVelocity = new Vector2(direction * chargeSpeed, rb.linearVelocity.y);

            timer += Time.deltaTime;
            yield return null;
        }

        // Para o movimento no fim da investida
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

        isCharging = false;
    }
}
