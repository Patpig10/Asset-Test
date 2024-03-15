using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CowController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 wanderTarget;
    public Transform playerTransform;
    public float wanderRadius = 10f;
    public float wanderTimer = 5f;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        SetNewRandomDestination();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            SetNewRandomDestination();
        }

        if (playerTransform != null)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            // If player is in front of the cow, move away
            if (angle < 90f)
            {
                Vector3 moveAwayDirection = transform.position - playerTransform.position;
                agent.SetDestination(transform.position + moveAwayDirection);
            }
        }
    }

    void SetNewRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, wanderRadius, -1);
        wanderTarget = navHit.position;
        agent.SetDestination(wanderTarget);
        timer = 0;
    }
}