using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit1()
    {
        Debug.Log("Quitting game..."); // Optional: Log a message to console
        Application.Quit(); // Quit the application
    }
}
