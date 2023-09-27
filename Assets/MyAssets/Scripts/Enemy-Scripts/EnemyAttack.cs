using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 40;

    private EnemyAI enemyAI;

    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void AttackHitEvent()
    {
        Transform target = enemyAI.target;
        if (target == null)
        {
            return;
        }

        target.GetComponent<PlayerHealth>().TakeDamage(damage);
        Debug.Log("Hit!");
    }

}
