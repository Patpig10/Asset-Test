using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public UnityEvent interact;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact.Invoke();
        }
    }
}
