using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float visionRange = 10f;
    [SerializeField] private float proximityLimit = 1f;

    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = float.MaxValue;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();   
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        //navMeshAgent.SetDestination(target.position - (new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z).normalized * 2));
        if (distanceToTarget < visionRange && distanceToTarget > proximityLimit)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
}
