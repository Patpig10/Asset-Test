using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHolder : MonoBehaviour
{
    public static PointHolder instance;
    public int stars;

    // Ensure there's only one instance of PointHolder
    private void Awake()
    {
        // If instance doesn't exist, set it to this, otherwise destroy this object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevents the object from being destroyed when loading a new scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Optional: You can use this method to set stars value when needed
    public void SetStars(int value)
    {
        stars = value;
    }
}