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
}
