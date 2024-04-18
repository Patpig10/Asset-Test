using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Rivertimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool isRunning = false;
    public Place_Fence logcounter;
    public PointHolder pointHolder;
    public int points;
    public float x;
    public GameObject win;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;


    void Start()
    {
        // Automatically find the PointHolder component in the scene
        pointHolder = FindObjectOfType<PointHolder>();

        // Check if the PointHolder component is found
        if (pointHolder == null)
        {
            Debug.LogError("PointHolder component not found!");
        }
        StartTimer();
    }

    void Update()

    {


        if (isRunning)
        {
            float t = Time.time - startTime;
            x = t;
            Debug.Log("Timer value: " + t);

            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;



        }
        if (pointHolder.logs == 7) // Only award points if hayCounter.finish is true
        {
            win.SetActive(true);
            if (x <= 60)
            {
                Star1.SetActive(true);
                Star2.SetActive(true);
                Star3.SetActive(true);
                pointHolder.Logpoints = 3;
                Debug.Log("Points awarded: " + pointHolder.stars);

            }
            else if (x <= 120 && x > 60)
            {
                pointHolder.points = 2;
                Debug.Log("Points awarded: " + pointHolder.stars);
                Star1.SetActive(true);
                Star2.SetActive(true);
            }
            else if (x >= 180)
            {
                pointHolder.points = 1;
                Debug.Log("Points awarded: " + pointHolder.stars);
                Star1.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        startTime = Time.time;
    }
}
