using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomInFOV = 25f;
    [SerializeField] float zoomOutFOV = 60f;

    RigidbodyFirstPersonController fpsController;

    [SerializeField] float mouseSensZoomedOutX = 2f;
    [SerializeField] float mouseSensZoomedOutY = 2f;
    [SerializeField] float mouseSensZoomedInX = 1f;
    [SerializeField] float mouseSensZoomedInY = 1f;
    bool isZoomedIn = false;

    private void Start()
    {
        fpsController = FindObjectOfType<RigidbodyFirstPersonController>();
    }

    private void OnDisable()
    {
        WeaponZoomOut();
    }


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
        fpsController.mouseLook.XSensitivity = mouseSensZoomedInX;
        fpsController.mouseLook.YSensitivity = mouseSensZoomedInY;
        isZoomedIn = true;
    }

    private void WeaponZoomOut()
    {
        Camera.main.fieldOfView = zoomOutFOV;
        fpsController.mouseLook.XSensitivity = mouseSensZoomedOutX;
        fpsController.mouseLook.YSensitivity = mouseSensZoomedOutY;
        isZoomedIn = false;
    }
}
