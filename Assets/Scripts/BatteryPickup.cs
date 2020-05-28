using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 70f;
    [SerializeField] float restoreIntensity = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FlashlightSystem myFlashlight = FindObjectOfType<FlashlightSystem>();
            myFlashlight.RestoreLightAngle(restoreAngle);
            myFlashlight.RestoreLightIntensity(restoreIntensity);
            Destroy(gameObject);
        }     
    }
}
