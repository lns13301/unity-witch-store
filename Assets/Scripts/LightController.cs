using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    private Light2D light2D;
    [SerializeField] private bool isIntensityUp = true;

    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
        StartCoroutine("Repeat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Repeat()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        while (true)
        {
            ChangeIntensityUp();
            ChangeIntensity();
            yield return waitForSeconds;
        }
    }

    private void ChangeIntensityUp()
    {
        if (isIntensityUp && light2D.intensity > 0.2f)
        {
            isIntensityUp = false;
        }
        else if (!isIntensityUp && light2D.intensity < 0.1f)
        {
            isIntensityUp = true;
        }
    }

    private void ChangeIntensity()
    {
        if (isIntensityUp)
        {
            light2D.intensity += Time.deltaTime;
        }
        else
        {
            light2D.intensity -= Time.deltaTime;
        }
    }
}
