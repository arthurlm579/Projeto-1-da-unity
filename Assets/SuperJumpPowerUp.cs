using UnityEngine;

public class SuperJumpPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement2D player = collision.GetComponent<PlayerMovement2D>();

        if (player != null)
        {
            player.EnableSuperJump(); // ativa no player
            Destroy(gameObject);      // remove o item
        }
    }
}
