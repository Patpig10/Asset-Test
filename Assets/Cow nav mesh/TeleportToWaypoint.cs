using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToWaypoint : MonoBehaviour
{
    public Transform waypoint;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.transform);
        }
    }

   public void TeleportPlayer(Transform playerTransform)
    {
        if (waypoint != null)
        {
            // Teleport the player to the waypoint's position
            playerTransform.position = waypoint.position;
            // Optionally, you can also orient the player's rotation to match the waypoint's rotation
            playerTransform.rotation = waypoint.rotation;
        }
        else
        {
            Debug.LogWarning("Waypoint is not assigned!");
        }
    }
}
