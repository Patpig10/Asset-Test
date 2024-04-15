using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire_Enabler : MonoBehaviour
{
    int poles = 0;
    BoxCollider col;
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PoleUP()
    {
        poles++;
        if (poles >= 4)
        {
            col.enabled = true;
        }
    }
}
