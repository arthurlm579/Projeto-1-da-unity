using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // Referência ao Player
    public float smoothSpeed = 0.125f; // Suavidade do movimento
    public Vector3 offset;     // Distância entre a câmera e o player

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}