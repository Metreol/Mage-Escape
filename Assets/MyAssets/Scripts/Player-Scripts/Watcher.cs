using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Watcher : MonoBehaviour
{
    [SerializeField] private float visionRange = 20f;
    [SerializeField] private float lookHeightAdjustment = 3f;
    [SerializeField] private List<Transform> watchers; // Usually eyes?

    private EnemyAI enemyAI;

    private float distanceToTarget = float.MaxValue;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    void Update()
    {
        Transform target = enemyAI.target;

        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < visionRange)
        {
            foreach (Transform watcher in watchers) {
                watcher.LookAt(target.position + (Vector3.up * lookHeightAdjustment));
            }
        }
    }
}
