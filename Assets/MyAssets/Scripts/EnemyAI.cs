using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float turnSpeed = 10f;

    public Transform target;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float distanceToTarget = float.MaxValue;
    private bool provoked = false;


    void Start()
    {
        PlayerHealth[] players = FindObjectsOfType<PlayerHealth>();
        GetComponent<EnemyHealth>().OnDamageTaken += EnemyAI_OnDamageTaken;
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

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
    }

    private void EnemyAI_OnDamageTaken(object sender, System.EventArgs e)
    {
        this.provoked = true;
        Debug.Log("PROVOKED");
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        
        if (provoked || distanceToTarget < detectionRange)
        {
            if (distanceToTarget > attackRange)
            {
                ChaseTarget();
            }
            else
            {
                AttackTarget();
            }
            provoked = false;
        }
        else if (Vector3.Distance(transform.position, navMeshAgent.destination) < navMeshAgent.stoppingDistance
            && navMeshAgent.velocity.magnitude < 0.01f)
        {
            Idle();
        }
    }

    private void Idle()
    {
        navMeshAgent.SetDestination(transform.position);
        animator.SetBool("Move", false);
    }

    private void ChaseTarget()
    {
        animator.SetBool("Attack", false);
        animator.SetBool("Move", true);
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        navMeshAgent.SetDestination(transform.position);
        animator.SetBool("Attack", true);
        FaceTarget();
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
