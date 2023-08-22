using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Watcher : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float visionRange = 20f;
    [SerializeField] private float lookHeightAdjustment = 3f;

    private float distanceToTarget = float.MaxValue;

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < visionRange)
        {
            transform.LookAt(target.position + (Vector3.up * lookHeightAdjustment));
        }
    }
}
