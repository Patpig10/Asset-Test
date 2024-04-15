using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Tape_Check : MonoBehaviour
{
    RectTransform rectTransform;
    public UnityEvent fin;
    public bool dragged = false;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rectTransform.position.x < 420 && rectTransform.position.x > 388 &&
            rectTransform.position.y < 280 && rectTransform.position.y > 235)
        {
                fin.Invoke();
        }
        else if (rectTransform.position.x < 640 && rectTransform.position.x > 580 &&
           rectTransform.position.y < 430 && rectTransform.position.y > 350)
        {
            fin.Invoke();
        }
        print(rectTransform.position);
    }

    public void Dragging()
    {
        dragged = !dragged;
    }
}
