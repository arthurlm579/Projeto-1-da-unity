using UnityEngine;

public class ObstaculoAlternante : MonoBehaviour
{
    [Header("Configurações")]
    public float tempoVisivel = 2f;   // tempo que o obstáculo fica ativo
    public float tempoInvisivel = 2f; // tempo que o obstáculo fica desativado

    private Collider2D col;
    private SpriteRenderer sr;

    void Start()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(CicloAparecerSumir());
    }

    System.Collections.IEnumerator CicloAparecerSumir()
    {
        while (true)
        {
            // Fica visível e com colisão
            if (sr != null) sr.enabled = true;
            col.enabled = true;
            yield return new WaitForSeconds(tempoVisivel);

            // Some e perde colisão
            if (sr != null) sr.enabled = false;
            col.enabled = false;
            yield return new WaitForSeconds(tempoInvisivel);
        }
    }
}