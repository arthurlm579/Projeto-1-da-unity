using UnityEngine;

public class VerticalOscillator : MonoBehaviour
{
    [Header("Configuração")]
    public float amplitude = 2f;      // distância máxima (metade do percurso)
    public float speed = 2f;          // velocidade do ciclo
    public Vector2 direction = Vector2.up; // direção principal (use Vector2.up para vertical)
    public bool usePingPong = true;   // true = Move entre dois pontos com Mathf.PingPong; false = seno suave

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        direction = direction.normalized;
    }

    void Update()
    {
        float t = Time.time * speed;
        float offset;
        if (usePingPong)
        {
            // vai de -amplitude a +amplitude de forma "ping-pong"
            offset = Mathf.PingPong(t, amplitude * 2f) - amplitude;
        }
        else
        {
            // movimento suave seno
            offset = Mathf.Sin(t) * amplitude;
        }

        transform.position = startPos + (Vector3)direction * offset;
    }
}
