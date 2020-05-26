using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }


    public void TakeDamage(int damage)
    {
        hitPoints -= damage;

        GetComponent<EnemyAI>().OnDamageTaken();

        if (hitPoints <= 0)
        {
            EnemyDeathSequence();
        }
    }

    private void EnemyDeathSequence()
    {
        GetComponent<Animator>().SetTrigger("die");
        isDead = true;
    }
}
