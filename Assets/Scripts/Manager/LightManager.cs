using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public static LightManager instance;

    [SerializeField] private Light2D globalLight;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Initialize()
    {
        globalLight = GameObject.Find("Light").transform.Find("Global Light 2D").GetComponent<Light2D>();
    }

    public void SetGlobalLightIntensity(float intensity)
    {
        globalLight.intensity = intensity;
    }
}