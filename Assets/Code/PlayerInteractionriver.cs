using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionriver : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    private Place_Fence currentInteraction;
    public GameObject interactionPopup;
    public float interactionDistance = 3f;
    public LayerMask interactionMask;
    public string interactableTag = "Interactable";

    void Update()
    {
        // Check if the interact key is pressed
        if (Input.GetKeyDown(interactKey))
        {
            Debug.Log("Interact key pressed");
            // Check if there's a valid interaction available
            if (currentInteraction != null)
            {
                Debug.Log("Performing interaction");
                // Perform the interaction
                currentInteraction.Interact1();
            }
        }

        // Check if the player is close enough to interact with an object
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactionMask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                currentInteraction = hit.collider.GetComponent<Place_Fence>();
                if (currentInteraction != null)
                {
                    // Show interaction popup if player is looking at the object
                    interactionPopup.SetActive(true);
                }
            }
            else
            {
                interactionPopup.SetActive(false);
                currentInteraction = null;
            }
        }
        else
        {
            interactionPopup.SetActive(false);
            currentInteraction = null;
        }
    }

    // Triggered when the player enters the interaction zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider has an Interaction component
        Place_Fence interaction = other.GetComponent<Place_Fence>();
        if (interaction != null)
        {
            // Set the current interaction
            currentInteraction = interaction;
        }
    }

    // Triggered when the player exits the interaction zone
    private void OnTriggerExit(Collider other)
    {
        // Reset the current interaction
        currentInteraction = null;
    }
}
