using UnityEngine;

public class BolaController2D : MonoBehaviour
{
    // Detecta colisões com outros objetos 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("A bola colidiu com: " + collision.gameObject.name);
    }
}