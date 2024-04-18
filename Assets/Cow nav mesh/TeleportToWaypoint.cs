using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToWaypoint : MonoBehaviour
{
    public Transform waypoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered teleporter!");
            TeleportPlayer(other.transform);
        }
    }

    private void TeleportPlayer(Transform playerTransform)
    {
        if (waypoint != null)
        {
            playerTransform.position = waypoint.position;
            playerTransform.rotation = waypoint.rotation;
            Debug.Log("Player teleported to: " + waypoint.position);
        }
        else
        {
            Debug.LogWarning("Waypoint is not assigned!");
        }
    }
}
