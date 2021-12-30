using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float flickerIntensity = 0f;
    public float flickerPS = 0f;
    public float speedRand = 0f;

    private float time;
    private float startIntense;
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        startIntense = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * (1 - Random.Range(-speedRand, speedRand)) * Mathf.PI;
        light.intensity = startIntense + Mathf.Sin(time * flickerPS) * flickerIntensity;
    }
}
