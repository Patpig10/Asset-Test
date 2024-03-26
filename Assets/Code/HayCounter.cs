using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HayCounter : MonoBehaviour
{
    public int Hay = 0;
    public bool finish = false;
    public DigitalTimer timer;
    // Start is called before the first frame update
    public void Start()
    {

    }

    public void hay()
    {
        Hay++;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Hay == 3)
        {
            finish = true;
            Cursor.lockState = CursorLockMode.None;
            timer.StopTimer();

        }
    }
}
