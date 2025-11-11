using UnityEngine;

public class DashPickup : MonoBehaviour
{
    public FadeMessage dashMessage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var dash = collision.GetComponent<PlayerDash>();
            if (dash != null)
                dash.canDash = true;

            // Chama o efeito de fade
            dashMessage.ShowMessage();

            Destroy(gameObject);
        }
    }
}
