using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Place_Fence : MonoBehaviour
{
    public UnityEvent Interact;
    public GameObject FencePickUp;
    public PickUpFence PickUpFence;
    // Start is called before the first frame update
    void Start()
    {
        FencePickUp = GameObject.Find("LogPickUP");
        PickUpFence = FencePickUp.GetComponentInChildren<PickUpFence>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Mouse0) && other.CompareTag("Player") && PickUpFence.logs > 0)
        {
            Interact.Invoke();
            PickUpFence.logs--;
        }
        
    }
}
