using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    public PointHolder pointHolder;
    // Start is called before the first frame update
    void Start()
    {
        pointHolder = FindObjectOfType<PointHolder>();

        // Check if the PointHolder component is found
        if (pointHolder == null)
        {
            Debug.LogError("PointHolder component not found!");
        }
    }
    public void Reset()
    {
        pointHolder.logs = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
