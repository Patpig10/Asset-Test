using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PathFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public bool forward = true;
    public GameObject FencePickUp;
    public PickUpFence PickUpFence;
    private bool rotated = false; // Flag to track if rotation has been performed

    void Start()
    {
        FencePickUp = GameObject.Find("LogPickUP");
        PickUpFence = FencePickUp.GetComponentInChildren<PickUpFence>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotated) // Check if rotation hasn't been performed yet
        {
            // Rotate the object 180 degrees around Y-axis
            transform.Rotate(0f, 180f, 0f);
            rotated = true; // Set the flag to true after rotating
            transform.position += transform.forward * -0.1f;
        }

        if (forward)
        {
            // Move the object forward
            transform.position += transform.forward * 0.1f; // Move along object's forward direction
        }
        else
        {
            // Rotate the object back to its original rotation
            if (rotated) // Check if rotation has been performed
            {
                transform.Rotate(0f, 180f, 0f); // Rotate back 180 degrees
                rotated = false; // Reset the flag
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        forward = !forward;

        if (other.CompareTag("Player"))
        {
            PickUpFence.logs--;
        }
    }
}
