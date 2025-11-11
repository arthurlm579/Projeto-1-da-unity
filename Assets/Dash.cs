using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TrailRenderer))]
public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;
    public float dashTime = 0.15f;
    public float dashCooldown = 1f;
    public bool canDash = false;
    public KeyCode dashKey = KeyCode.Q;

    private Rigidbody2D rb;
    private TrailRenderer trail;   // ✅ AQUI O RASTRO

    private bool isDashing = false;
    private bool isOnCooldown = false;
    private float dashTimer;
    private float cooldownTimer;
    private float dashDirection = 1f;

    private float originalGravity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // ✅ AQUI ESTAVA FALTANDO!!!
        trail = GetComponent<TrailRenderer>();
        trail.emitting = false;
    }

    void Update()
    {
        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0f)
                isOnCooldown = false;
        }

        if (canDash && !isOnCooldown && !isDashing && Input.GetKeyDown(dashKey))
            StartDash();

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0f)
                EndDash();
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
            rb.linearVelocity = new Vector2(dashDirection * dashSpeed, 0f);
    }

    void StartDash()
    {
        float h = Input.GetAxisRaw("Horizontal");
        dashDirection = h != 0 ? Mathf.Sign(h) : (transform.localScale.x >= 0 ? 1 : -1);

        isDashing = true;
        dashTimer = dashTime;

        originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

        // ✅ AGORA O RASTRO LIGA
        trail.emitting = true;

        Debug.Log("Dash iniciado!");
    }

    void EndDash()
    {
        isDashing = false;

        rb.gravityScale = originalGravity;

        // ✅ E AGORA DESLIGA
        trail.emitting = false;

        isOnCooldown = true;
        cooldownTimer = dashCooldown;

        Debug.Log("Dash terminou!");
    }
}
