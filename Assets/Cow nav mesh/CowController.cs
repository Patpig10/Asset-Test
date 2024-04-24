using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CowController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 currentDestination;
    private bool reachedDestination = true;
    public float wanderRadius = 10f;
    public float turnDistance = 1f; // Distance threshold to trigger direction change
    public float avoidanceDistance = 2f; // Distance to avoid obstacles
    public float gizmoSphereSize = 0.5f; // Size of debug sphere in Gizmos

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

        // Mark that the cow has reached the current destination
        reachedDestination = true;
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
        // Check for nearby obstacles tagged as "cow"
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, avoidanceDistance);

        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.CompareTag("cow") && collider.gameObject != gameObject)
            {
                Vector3 avoidanceDirection = transform.position - collider.transform.position;
                currentDestination = transform.position + avoidanceDirection.normalized * agent.stoppingDistance;
                break; // Stop checking once an obstacle is found and avoided
            }
        }
    }

    void OnDrawGizmos()
    {
        // Draw the current destination point
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(currentDestination, gizmoSphereSize);
    }
}
