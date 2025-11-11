using UnityEngine;
using TMPro;
using System.Collections;

public class FadeMessage : MonoBehaviour
{
    public float fadeInTime = 0.5f;   // tempo pra aparecer
    public float visibleTime = 2f;    // tempo visível
    public float fadeOutTime = 0.5f;  // tempo pra sumir

    private TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        SetAlpha(0);           // começa invisível
        gameObject.SetActive(false);
    }

    public void ShowMessage()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        // FADE IN
        yield return StartCoroutine(Fade(0f, 1f, fadeInTime));

        // Fica visível
        yield return new WaitForSeconds(visibleTime);

        // FADE OUT
        yield return StartCoroutine(Fade(1f, 0f, fadeOutTime));

        gameObject.SetActive(false); // desativa depois
    }

    IEnumerator Fade(float start, float end, float duration)
    {
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            float a = Mathf.Lerp(start, end, t / duration);
            SetAlpha(a);
            yield return null;
        }
    }

    void SetAlpha(float a)
    {
        if (text != null)
        {
            Color c = text.color;
            c.a = a;
            text.color = c;
        }
    }
}
