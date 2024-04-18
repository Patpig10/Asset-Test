using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fairybgone : MonoBehaviour
{
    private PointHolder pointHolder; // Reference to the PointHolder component
    public GameObject Fiary;
    public GameObject Fiary2;



    // Start is called before the first frame update
    void Start()
    {
        // Automatically find the PointHolder component in the scene
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
        // Check if the PointHolder component is null
        if (pointHolder == null)
        {
            return;
        }

        if (pointHolder.fairy >= 1)
        {
            Fiary.SetActive(false);
            Fiary2.SetActive(false);


        }

        if (pointHolder.fairy == 1)
        {
            Fiary2.SetActive(true);

        }
    }

    public void done()
    {
        pointHolder.fairy++;
    }
}
