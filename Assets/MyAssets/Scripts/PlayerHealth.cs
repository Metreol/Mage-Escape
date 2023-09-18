using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float fullHealth = 100f;

    private float health;

    void Start()
    {
        health = fullHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= Mathf.Abs(damage);
        health = health <= 0 ? 0 : health;
        if (health <= 0)
        {
            Debug.Log("Player died");
        }
    }

    public void RestoreHealth(float heal)
    {
        health += Mathf.Abs(heal);
        health = health > fullHealth ? fullHealth : health;
    }
}
