using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomInFOV = 25f;
    [SerializeField] float zoomOutFOV = 60f;

    bool isZoomedIn = false;


    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (isZoomedIn)
            {
                WeaponZoomOut();
            }
            else
            {
                WeaponZoomIn();
            }
        }

    }

    private void WeaponZoomIn()
    {
        Camera.main.fieldOfView = zoomInFOV;
        isZoomedIn = true;
    }

    private void WeaponZoomOut()
    {
        Camera.main.fieldOfView = zoomOutFOV;
        isZoomedIn = false;
    }
}
