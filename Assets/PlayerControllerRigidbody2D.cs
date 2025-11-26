using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float accelerationFactor = 15f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 10f;

    [Header("Super Jump")]
    [SerializeField] private float maxChargeTime = 1.5f;
    [SerializeField] private float maxSuperJumpForce = 22f;
    [SerializeField] private ParticleSystem chargeParticles;

    private bool superJumpEnabled = false;
    private bool isCharging = false;
    private float chargeTimer = 0f;

    [Header("Ground Check")]
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = false;
    private float horizontalInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.bodyType = RigidbodyType2D.Dynamic;

        if (chargeParticles != null)
            chargeParticles.Stop(); // impede partículas no início
    }

    void Update()
    {
        // ATIVADOR/DESATIVADOR DO SUPER JUMP (tecla E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            superJumpEnabled = !superJumpEnabled;
            Debug.Log("Super Jump ativo: " + superJumpEnabled);

            if (!superJumpEnabled)
                StopCharging();
        }

        // Movimento
        horizontalInput = Input.GetAxis("Horizontal");

        // Lógica do pulo normal
        if (!superJumpEnabled)
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            SuperJumpLogic();
        }
    }

    void SuperJumpLogic()
    {
        // Começar a carregar
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            if (!isCharging)
            {
                isCharging = true;
                chargeTimer = 0f;

                if (chargeParticles != null)
                    chargeParticles.Play();
            }

            chargeTimer += Time.deltaTime;
            chargeTimer = Mathf.Clamp(chargeTimer, 0f, maxChargeTime);
        }

        // Soltar espaço => super jump
        if (Input.GetKeyUp(KeyCode.Space) && isCharging)
        {
            float chargePercent = chargeTimer / maxChargeTime;
            float force = Mathf.Lerp(jumpForce, maxSuperJumpForce, chargePercent);

            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

            StopCharging();
        }
    }

    void StopCharging()
    {
        isCharging = false;
        chargeTimer = 0f;

        if (chargeParticles != null)
            chargeParticles.Stop();
    }

    void FixedUpdate()
    {
        // Verificação de chão
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, groundCheckDistance, groundLayer);
        bool wasGrounded = isGrounded;
        isGrounded = hit.collider != null;

        if (isGrounded && !wasGrounded)
            StopCharging();

        // Flip
        if (horizontalInput > 0)
            spriteRenderer.flipX = false;
        else if (horizontalInput < 0)
            spriteRenderer.flipX = true;

        // Movimento suave
        float targetVelocityX = horizontalInput * speed;

        float newVelocityX = Mathf.Lerp(
            rb.linearVelocity.x,
            targetVelocityX,
            accelerationFactor * Time.fixedDeltaTime
        );

        rb.linearVelocity = new Vector2(newVelocityX, rb.linearVelocity.y);
    }

    // MÉTODO USADO PELO POWER UP
    public void EnableSuperJump()
    {
        superJumpEnabled = true;
    }
}
