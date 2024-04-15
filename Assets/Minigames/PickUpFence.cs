using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PickUpFence : MonoBehaviour
{
    public UnityEvent Interact;
    public int logs = 0;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (logs > 4)
        {
            logs = 4;
        }
        text.text = logs.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && other.CompareTag("Player"))
        {
            Interact.Invoke();
            logs++;
        }

    }
}
