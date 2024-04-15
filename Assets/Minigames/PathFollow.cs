using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public bool forward = true;
    public GameObject FencePickUp;
    public PickUpFence PickUpFence;
    void Start()
    {
        FencePickUp = GameObject.Find("LogPickUP");
        PickUpFence = FencePickUp.GetComponentInChildren<PickUpFence>();
    }

    // Update is called once per frame
    void Update()
    {
        if (forward)
        {
            transform.position = new Vector3(transform.position.x + 0.1f,transform.position.y,transform.position.z);
        }
        else if (!forward)
        {
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
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
