using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float totalHealth = 30f;

    private float currentHealth;

    private void Start()
    {
        currentHealth = totalHealth;
    }

    public void DecreaseHealth(float damage)
    {
        this.OnDamageTaken?.Invoke(this, null);
        currentHealth -= damage;
        if (currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseHealth(float damage)
    {
        if (currentHealth + damage >= totalHealth)
        {
            currentHealth = totalHealth;
        }
        else
        {
            currentHealth += damage;
        }
    }

    // An event that will be called when the Enemy takes damage.
    // NOTE: If environmental damage is added later, or multiple players, this will
    // need modified as WHO does the damage will need to be taken into account.
    public event EventHandler OnDamageTaken;
}
