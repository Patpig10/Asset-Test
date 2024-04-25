using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CowController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 currentDestination;
    private bool reachedDestination = true;
    private float destinationTimer = 0f;
    public float wanderRadius = 10f;
    public float turnDistance = 1f; // Distance threshold to trigger direction change
    public float avoidanceDistance = 2f; // Distance to avoid obstacles
    public float gizmoSphereSize = 0.5f; // Size of debug sphere in Gizmos
    public float maxDestinationWaitTime = 10f; // Maximum time to wait before changing destination

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Disable automatic rotation by NavMeshAgent
        agent.stoppingDistance = 1f; // Set stopping distance to prevent jittering near target

        SetNewRandomDestination();
    }

    void Update()
    {
        if (reachedDestination && !agent.pathPending && agent.remainingDistance < agent.stoppingDistance)
        {
            // Cow has reached the current destination, trigger direction change
            reachedDestination = false;
            StartCoroutine(ChangeDirection());
        }
        else
        {
            // Increment timer while waiting to reach destination
            destinationTimer += Time.deltaTime;

            // Check if the timer exceeds the maximum wait time
            if (destinationTimer >= maxDestinationWaitTime)
            {
                // Timer exceeded, change direction and set new destination
                SetNewRandomDestination();
                reachedDestination = true; // Consider destination reached to reset the timer
                destinationTimer = 0f; // Reset timer
            }
        }

        // Update the agent's destination
        agent.SetDestination(currentDestination);

        // Face the direction of movement
        RotateTowardsMovementDirection();

        // Avoid bumping into obstacles
        AvoidBumpingObstacles();
    }

    IEnumerator ChangeDirection()
    {
        // Wait for a short delay before changing direction
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        // Set a new random destination point
        SetNewRandomDestination();

        // Reset destination timer
        destinationTimer = 0f;
    }

    void SetNewRandomDestination()
    {
        // Calculate a random point within the wander radius
        Vector3 randomDirection = Random.insideUnitSphere.normalized * wanderRadius;
        currentDestination = transform.position + randomDirection;
    }

    void RotateTowardsMovementDirection()
    {
        // Get the velocity of the NavMeshAgent
        Vector3 velocity = agent.velocity;

        if (velocity.magnitude > 0.1f)
        {
            // Calculate the rotation to look towards the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(velocity.normalized);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * agent.angularSpeed);
        }
    }

    void AvoidBumpingObstacles()
    {
        // Check for nearby obstacles and other cows
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, avoidanceDistance);

        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject != gameObject) // Ignore self
            {
                // Check if the cow is heading towards another cow or an obstacle
                if (collider.gameObject.CompareTag("cow") || collider.gameObject.CompareTag("obstacle"))
                {
                    // Calculate the avoidance direction away from the obstacle
                    Vector3 avoidanceDirection = transform.position - collider.transform.position;

                    // Update the destination point to avoid the obstacle
                    currentDestination = transform.position + avoidanceDirection.normalized * avoidanceDistance;

                    // Check if the cow is stuck (not moving towards the new point)
                    if (Vector3.Distance(transform.position, agent.destination) < turnDistance)
                    {
                        // Cow is likely stuck, generate a new random destination
                        SetNewRandomDestination();
                    }

                    // Exit the loop after handling one obstacle
                    break;
                }
            }
        }

        // Check for collision with obstacles
        if (agent.velocity.magnitude > 0f && agent.isStopped)
        {
            // Cow is colliding with an obstacle and stopped moving
            SetNewRandomDestination(); // Change direction
            reachedDestination = true; // Reset reachedDestination flag
        }
    }

    void OnDrawGizmos()
    {
        // Draw the current destination point
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(currentDestination, gizmoSphereSize);
    }
}
