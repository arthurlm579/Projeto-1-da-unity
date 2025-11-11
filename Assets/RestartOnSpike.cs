using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnSpike : MonoBehaviour
{
    // Detecta colisão com o espeto
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Espeto"))
        {
            // Recarrega a cena atual (reinicia a fase)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Também funciona se o espeto usar trigger em vez de collider normal
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Espeto"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}