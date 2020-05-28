using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float shootRange = 100f;
    [SerializeField] int damage = 10;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitSparks;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float cooldownTime = 0.5f;

    [SerializeField] TextMeshProUGUI ammoDisplay;

    bool isAbleToShoot = true;

    private void OnEnable()
    {
        isAbleToShoot = true;
        UpdateAmmoDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoSlot.GetCurrentAmmo(ammoType) > 0 && isAbleToShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
        ammoSlot.DecreaseAmmoAmount(ammoType);
        UpdateAmmoDisplay();
        isAbleToShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        isAbleToShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, shootRange))
        {
            Debug.Log("I hit" + hit.transform.name);

            PlayHitParticles(hit);
            


            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
        else
        {
            return;
        }
    }

    private void PlayHitParticles(RaycastHit hit)
    {
        GameObject hitEffect = Instantiate(hitSparks, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffect, 0.2f);
    }

    public void UpdateAmmoDisplay()
    {
        ammoDisplay.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }
}
