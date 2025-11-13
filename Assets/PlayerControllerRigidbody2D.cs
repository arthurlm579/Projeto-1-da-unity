using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))] // Adicionado para garantir que o Flip funcione
public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float accelerationFactor = 15f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 10f;

    [Header("Ground Check")]
    // Distância máxima do raio para o chão
    [SerializeField] private float groundCheckDistance = 0.2f;
    // Camada que define o que é considerado chão (Configurar no Inspector!)
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = false;
    private float horizontalInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.isKinematic = false;

        // Configura detecção contínua para evitar interpenetração (problema de "túnel")
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        // 1. COLETAR INPUTS no Update()
        horizontalInput = Input.GetAxis("Horizontal");

        // 2. LÓGICA DO PULO no Update()
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // 3. CHECAGEM DE CHÃO COM RAYCAST no FixedUpdate()
        Vector2 raycastOrigin = rb.position;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, groundCheckDistance, groundLayer);

        isGrounded = (hit.collider != null);

        // 4. LÓGICA DE VIRAR O PERSONAGEM (FLIP)
        if (horizontalInput > 0) // Movendo para a direita
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0) // Movendo para a esquerda
        {
            spriteRenderer.flipX = true;
        }

        // 5. MOVIMENTO HORIZONTAL SUAVIZADO POR VELOCIDADE

        // Define a velocidade alvo para o eixo X
        float targetVelocityX = horizontalInput * speed;

        // Interpola (suaviza) a velocidade X atual para a velocidade alvo.
        float newVelocityX = Mathf.Lerp(
            rb.linearVelocity.x,
            targetVelocityX,
            accelerationFactor * Time.fixedDeltaTime
        );

        // Aplica a nova velocidade X, PRESERVANDO A VELOCIDADE Y para o pulo/gravidade.
        rb.linearVelocity = new Vector2(newVelocityX, rb.linearVelocity.y);
    }
}