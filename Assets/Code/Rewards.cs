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
            Reward2.SetActive(false);
            Reward3.SetActive(false);
            Reward4.SetActive(false);
        }
        if (pointHolder.stars == 6)
        {
            Reward2.SetActive(true);
            Star2.SetActive(true);
            Reward3.SetActive(false);
            Reward4.SetActive(false);
            Reward1.SetActive(true);
        }
        if (pointHolder.stars == 9)
        {
            Reward3.SetActive(true);
            Star3.SetActive(true);
            Reward4.SetActive(false);
            Reward1.SetActive(true);
            Reward2.SetActive(true);
        }
        if (pointHolder.stars == 12)
        {
            Reward4.SetActive(true);
            Star4.SetActive(true);
            Reward1.SetActive(true);
            Reward2.SetActive(true);
            Reward3.SetActive(true);
           
        }
    }
}
