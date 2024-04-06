using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectcounter : MonoBehaviour
{

    public int Collect = 0;
    public bool finish = false;
    public BarnTimer timer;
    // Start is called before the first frame update
    public void Start()
    {

    }

    public void hay()
    {
        Collect++;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Collect == 3)
        {
            finish = true;
            Cursor.lockState = CursorLockMode.None;
            timer.StopTimer();

        }
    }
}
