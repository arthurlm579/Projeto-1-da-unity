using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OrbGlow : MonoBehaviour
{
    private Light2D light2D;
    private float baseIntensity;
    public float speed = 2f;
    public float range = 0.5f;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        baseIntensity = light2D.intensity;
    }

    void Update()
    {
        light2D.intensity = baseIntensity + Mathf.Sin(Time.time * speed) * range;
    }
}