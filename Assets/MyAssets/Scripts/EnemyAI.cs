using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float attackRange = 3f;

    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = float.MaxValue;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();   
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < detectionRange)
        {
            EngageTarget();
        }
    }

    private void EngageTarget()
    {
        if (distanceToTarget < attackRange)
        {
            AttackTarget();
        }
        else
        {
            ChaseTarget();
        }
    }

    private void ChaseTarget()
    {
        //Debug.Log($"{name} is CHASING {target.name}!");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        //Debug.Log($"{name} is ATTACKING {target.name}!");
        navMeshAgent.SetDestination(transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
