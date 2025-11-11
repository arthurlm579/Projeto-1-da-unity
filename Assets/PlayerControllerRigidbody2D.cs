using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 5f;          // Velocidade horizontal
    public float jumpForce = 10f;     // For�a do pulo
    private Rigidbody2D rb;
    private bool isGrounded = false;  // Para verificar se est� no ch�o

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento horizontal
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; // Evita pular v�rias vezes no ar
        }
    }

    // Detecta quando o player encosta no ch�o
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}