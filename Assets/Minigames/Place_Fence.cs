using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Place_Fence : MonoBehaviour
{
    public UnityEvent Interact;
    public GameObject FencePickUp;
    public PickUpFence PickUpFence;
    public PointHolder pointHolder;
    public Rivertimer timer;
    public bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        FencePickUp = GameObject.Find("LogPickUP");
        PickUpFence = FencePickUp.GetComponentInChildren<PickUpFence>();
        pointHolder = FindObjectOfType<PointHolder>();

        // Check if the PointHolder component is found
        if (pointHolder == null)
        {
            Debug.LogError("PointHolder component not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pointHolder.logs == 7)
        {
            timer.StopTimer();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Mouse0) && other.CompareTag("Player") && PickUpFence.logs > 0)
        {
            Interact.Invoke();
            PickUpFence.logs--;
            pointHolder.logs++;
        }
        
    }
    public void Interact1()
    {
        if(PickUpFence.logs > 0)
        {
            Interact.Invoke();
            PickUpFence.logs--;
            pointHolder.logs++;
        }
       
    }

    public void done()
    {
        if (pointHolder.logs == 7)
        {

            finish = true;

        }

    }
}
