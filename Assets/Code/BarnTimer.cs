using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class BarnTimer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    private float startTime;
    private bool isRunning = false;
    public Collectcounter hayCounter;
    public PointHolder pointHolder;
    public int points;
    public float x;
    public GameObject win;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    public UnityEvent showArrows;


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
        if (hayCounter.finish == true) // Only award points if hayCounter.finish is true
        {
            win.SetActive(true);
            if (x <= 60)
            {
                Star1.SetActive(true);
                Star2.SetActive(true);
                Star3.SetActive(true);
                pointHolder.points = 3;
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
        }

        if (x >= 60)
        {
            showArrows.Invoke();
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
