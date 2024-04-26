using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fiary2plus : MonoBehaviour
{
    // Start is called before the first frame update
    private PointHolder pointHolder; // Reference to the PointHolder component
    void Start()
    {

        pointHolder = FindObjectOfType<PointHolder>();




        // Check if the PointHolder component is found
        if (pointHolder == null)
        {
            Debug.LogError("PointHolder component not found!");
        }
    }
    public void remove()
    {
        pointHolder.fairy +=2;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
