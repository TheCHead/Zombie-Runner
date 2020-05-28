using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] Canvas damageCanvas;

    private void Start()
    {
        damageCanvas.enabled = false;
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;
        DisplayDamage();
        
        if (health <= 0)
        {
            PlayerDeathSequence();
        }
    }

    private void PlayerDeathSequence()
    {
        GetComponent<DeathHandler>().HandleDeath();
    }

    private void DisplayDamage()
    {
        StartCoroutine("DiplayDamageCanvas");
    }

    IEnumerator DiplayDamageCanvas()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(0.5f);
        damageCanvas.enabled = false;
    }
}
