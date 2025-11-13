using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // Referência ao Player

    // Agora é um fator de velocidade. Valores comuns: 5f a 10f.
    // Quanto MENOR for este valor, MAIS SUAVE e atrasada a câmera será.
    public float smoothSpeed = 5f;

    public Vector3 offset;       // Distância entre a câmera e o player

    void LateUpdate()
    {
        if (player != null)
        {
            // 1. Posição Desejada
            Vector3 desiredPosition = player.position + offset;

            // 2. Interpolação (Suavização)
            // Multiplicar por Time.deltaTime torna o movimento FRAME-INDEPENDENT,
            // garantindo a mesma suavidade em qualquer FPS.
            Vector3 smoothedPosition = Vector3.Lerp(
                transform.position,
                desiredPosition,
                smoothSpeed * Time.deltaTime // <--- MUDANÇA PRINCIPAL
            );

            // 3. Aplica a Posição
            // Mantemos o Z original da câmera (essencial para que ela não se mova no eixo de profundidade)
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}