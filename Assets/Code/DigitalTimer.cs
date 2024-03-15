using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DigitalTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool isRunning = true;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;
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