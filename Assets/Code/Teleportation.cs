using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform playerCamera;  // Reference to the player's camera
    public LayerMask teleportMask;  // Layer mask to filter where teleportation is allowed
    public GameObject teleportIndicatorPrefab;  // Prefab for the teleport indicator
    public float teleportRange = 10f;  // Maximum teleportation distance

    private GameObject teleportIndicator;  // Reference to the teleport indicator object
    private CharacterController characterController;  // Reference to the CharacterController component

    private void Start()
    {
        // Get the CharacterController component attached to the player
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Raycast from the camera to check for teleportation location
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, teleportRange, teleportMask))
        {
            // If hit, show the teleport indicator at the hit point
            ShowTeleportIndicator(hit.point);

            // If player clicks, teleport to the hit point
            if (Input.GetMouseButtonDown(0))
            {
                TeleportPlayer(hit.point);
            }
        }
        else
        {
            // If not hit, hide the teleport indicator
            HideTeleportIndicator();
        }
    }

    // Show the teleport indicator at the specified position
    private void ShowTeleportIndicator(Vector3 position)
    {
        if (teleportIndicator == null)
        {
            teleportIndicator = Instantiate(teleportIndicatorPrefab);
        }
        teleportIndicator.SetActive(true);

        // Set the indicator's position at the hit point's position on the ground
        teleportIndicator.transform.position = new Vector3(position.x, teleportIndicator.transform.position.y, position.z);
    }

    // Hide the teleport indicator
    private void HideTeleportIndicator()
    {
        if (teleportIndicator != null)
        {
            teleportIndicator.SetActive(false);
        }
    }

    // Teleport the player to the specified position (maintaining y-coordinate)
    private void TeleportPlayer(Vector3 position)
    {
        // Preserve the player's current y-coordinate
        position.y = transform.position.y;

        // Teleport the player to the specified position
        characterController.enabled = false; // Disable character controller to set position
        transform.position = position;
        characterController.enabled = true; // Re-enable character controller
        Debug.Log("Teleporting to: " + position);
    }

    private void OnDrawGizmos()
    {
        // Draw a gizmo to visualize teleport range
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, teleportRange);
    }
}
