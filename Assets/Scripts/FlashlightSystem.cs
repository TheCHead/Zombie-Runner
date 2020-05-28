using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.05f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;
    Light myFlashlight;

    // Start is called before the first frame update
    void Start()
    {
        myFlashlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        myFlashlight.intensity -= lightDecay * Time.deltaTime;
        if (myFlashlight.spotAngle > minAngle)
        {
            myFlashlight.spotAngle -= angleDecay * Time.deltaTime;
        }
        
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myFlashlight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float restoreIntensity)
    {
        myFlashlight.intensity = restoreIntensity;
    }
}
