using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float turnSpeed = 10f;

    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = float.MaxValue;

    void Start()
    {
        PlayerHealth[] players = FindObjectsOfType<PlayerHealth>();
        switch (players.Length)
        {
            case 0:
                Debug.LogError("No GameObejct with the PlayerHealth Component found, assumed no player in the Scene.");
                Application.Quit(); // Only for built game.
                UnityEditor.EditorApplication.isPlaying = false; // For running in editor
                break;
            case 1:
                target = players[0].transform;
                break;
            default:
                Debug.LogError("More than 1 GameObejct with the PlayerHealth Component found, assumed too many players in the Scene.");
                Application.Quit(); // Only for Built game.
                UnityEditor.EditorApplication.isPlaying = false; // For running in editor
                break;
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < detectionRange)
        {
            EngageTarget();
        }
        else if (navMeshAgent.velocity.magnitude < 0.1f)
        {
            GetComponent<Animator>().SetTrigger("Idle");
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
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        FaceTarget();
        navMeshAgent.SetDestination(transform.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
