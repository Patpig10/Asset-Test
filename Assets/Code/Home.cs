using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Home : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Cursor.lockState = CursorLockMode.None;

            // Load scene 0 (assuming scene 0 is the first scene in Build Settings)
            SceneManager.LoadScene(0);
        }
    }
}
