using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        // Movimento
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        // Inverte o sprite conforme a dire��o
        if (moveX > 0)
            sr.flipX = false; // olha pra direita
        else if (moveX < 0)
            sr.flipX = true;  // olha pra esquerda
    }
}