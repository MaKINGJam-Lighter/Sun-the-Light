using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class lightRadius : MonoBehaviour
{
    private UnityEngine.Experimental.Rendering.Universal.Light2D sunlight;
    private float radius;
    //private float time = 0f;


    float pos;
    float delta = 0.120f;
    float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        sunlight = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        pos = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        radius = pos;
        radius += delta * Mathf.Sin(Time.time * speed);
        sunlight.pointLightOuterRadius = radius;
    }

    void radiusIncreasing()
    {
        radius += Time.deltaTime * 630;
        radiusChange(radius);
    }

    void radiusDecreasing()
    {
        radius -= Time.deltaTime * 630;
        radiusChange(radius);
    }

    void radiusChange(float radius)
    {
        sunlight.pointLightOuterRadius = radius;
        Debug.Log(sunlight.pointLightOuterRadius);
    }
}
