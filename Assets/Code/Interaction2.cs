using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction2 : MonoBehaviour
{
    public UnityEvent Interact;
    public bool No = false;
    // Invoke the UnityEvent when the player interacts with the object
    public void Interact1()
    {
        if (No == false)
        {
            Debug.Log("Interact method called");
            Interact.Invoke();
        }
    }
    public void end()
    {
        No = true;
    }
}