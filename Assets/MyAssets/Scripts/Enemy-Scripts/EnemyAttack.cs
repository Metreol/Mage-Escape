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

    /* TODO : With Enemy-Wizard this doesn't work because the animation is READ-ONLY so I can't call the event
     * as part of the animation.
     * POTENTIAL SOLUTION: Give wizard attack much more range and add a projectile that does damage if it lands?
     * - Will require a good bit of a rework but should be interesting!
     * - Remember! This is still required for basic-enemy to work, keep this method for now at least or create 
     * different classes for each case.
     */
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
