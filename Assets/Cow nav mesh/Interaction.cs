using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public UnityEvent interact;
    private void OnTriggerEnter(Collider other)
    {
        interact.Invoke();
    }
}
