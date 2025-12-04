using UnityEngine;

public class DashPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var dash = collision.GetComponent<PlayerDash>();
            if (dash != null)
                dash.canDash = true;

            Destroy(gameObject);
        }
    }
}
