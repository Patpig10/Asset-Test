using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewards : MonoBehaviour
{
    public GameObject Reward1;
    public GameObject Reward2;
    public GameObject Reward3;
    public GameObject Reward4;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject Star4;
    private PointHolder pointHolder; // Reference to the PointHolder component

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

    void Update()
    {
        // Check if the PointHolder component is null
        if (pointHolder == null)
        {
            return; 
        }

        // Check the value of stars in PointHolder and activate corresponding rewards
        if (pointHolder.stars == 3)
        {
            Reward1.SetActive(true);
            Star1.SetActive(true);
          
        }
        if (pointHolder.points == 3)
        {
            Reward2.SetActive(true);
            Star2.SetActive(true);
           
        }
        if (pointHolder.mechs == 3)
        {
            Reward3.SetActive(true);
            Star3.SetActive(true);
           
        }
        if (pointHolder.Logpoints == 3)
        {
            Reward4.SetActive(true);
            Star4.SetActive(true);
           
           
        }
    }
}
