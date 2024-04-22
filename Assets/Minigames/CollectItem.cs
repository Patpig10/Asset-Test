using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectItem : MonoBehaviour
{
    public UnityEvent collect;
    
    private void OnTriggerEnter(Collider other)
    {
        collect.Invoke();
    }
}
