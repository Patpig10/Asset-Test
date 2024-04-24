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
    public float wanderTimer = 15f;
    private float timer;
    private bool shouldFlee = false;
    private float moveSpeed = 1.5f; // Adjust speed as needed

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed; // Set the agent's speed
        timer = wanderTimer;
        SetNewRandomDestination();
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Check if it's time to find a new destination
        if (timer >= wanderTimer)
        {
            SetNewRandomDestination();
        }

        // If the player is present and within sight, start fleeing from them
        if (playerTransform != null && !shouldFlee)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            // If player is in front of the cow (within a 90-degree cone), start fleeing
            if (angle < 90f)
            {
                shouldFlee = true;
               // MoveAwayFromPlayer(directionToPlayer);
            }
        }
    }

    void SetNewRandomDestination()
    {
        // Generate a random point within the wander radius
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit navHit;
        if (NavMesh.SamplePosition(randomDirection, out navHit, wanderRadius, NavMesh.AllAreas))
        {
            wanderTarget = navHit.position;
            agent.SetDestination(wanderTarget);
            timer = 0;
            shouldFlee = false; // Reset fleeing state when setting new destination
        }
    }

  /*  void MoveAwayFromPlayer(Vector3 directionToPlayer)
    {
        // Calculate the desired movement direction away from the player
        Vector3 moveDirection = -directionToPlayer.normalized;
        agent.velocity = moveDirection * moveSpeed; // Set the agent's velocity to move direction multiplied by speed
    }*/
}