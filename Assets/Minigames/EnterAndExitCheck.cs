using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterAndExitCheck : MonoBehaviour
{
    public UnityEvent Enter;
    public UnityEvent Exit;

    private void OnTriggerEnter(Collider other)
    {
        Enter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Exit.Invoke();
    }
}
