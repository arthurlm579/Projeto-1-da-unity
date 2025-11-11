using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float jumpForce = 15f; // agora dá pra mudar no Inspector
    private bool canJump = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canJump = false;
        }
    }

    private void Update()
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }
    }
}