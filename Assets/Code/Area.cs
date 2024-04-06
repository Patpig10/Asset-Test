using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Area : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public float delay = 3f;
    private bool hasActivated = false;

    private void Start()
    {
      //  ActivateObjectsWithDelay();
    }

    public void ActivateObjectsWithDelay()
    {
        // Invoke the ActivateObjects function after the specified delay
        Invoke("ActivateObjects", delay);
    }

    private void ActivateObjects()
    {
        // Check if objects haven't been activated yet
        if (!hasActivated)
        {
            // Activate all objects in the array
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
            // Set hasActivated to true to prevent repeated activations
            hasActivated = true;
        }
    }
}
