using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowButtonFade : MonoBehaviour
{
    public GameObject button;          // arraste o botão da UI
    public float fadeDuration = 0.5f;  // tempo do fade in/out
    public float visibleTime = 3f;     // tempo que o botão fica visível

    private CanvasGroup canvasGroup;
    private bool hasShown = false;     // controla se já apareceu uma vez

    private void Start()
    {
        // adiciona CanvasGroup se não tiver
        canvasGroup = button.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = button.AddComponent<CanvasGroup>();
        }

        button.SetActive(false);
        canvasGroup.alpha = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasShown)
        {
            hasShown = true; // marca que já foi mostrado
            StartCoroutine(ShowButton());
        }
    }

    IEnumerator ShowButton()
    {
        button.SetActive(true);

        // FADE IN
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;

        // Espera o tempo visível
        yield return new WaitForSeconds(visibleTime);

        // FADE OUT
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        button.SetActive(false);
    }
}
