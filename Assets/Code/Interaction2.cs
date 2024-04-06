using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction2 : MonoBehaviour
{
    public UnityEvent Interact;

    // Invoke the UnityEvent when the player interacts with the object
    public void Interact1()
    {
        Debug.Log("Interact method called");
        Interact.Invoke();
    }
}