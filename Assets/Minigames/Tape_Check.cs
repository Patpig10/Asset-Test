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
    public bool finished = false;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rectTransform.localPosition.x < 25 && rectTransform.localPosition.x > -20 &&
            rectTransform.localPosition.y < 50 && rectTransform.localPosition.y > 6)
        {
                fin.Invoke();
            finished = true;
        }
        /*else if (rectTransform.position.x < 640 && rectTransform.position.x > 580 &&
           rectTransform.position.y < 430 && rectTransform.position.y > 350)
        {
            fin.Invoke();
        }*/
        print(rectTransform.localPosition);
    }

    public void Dragging()
    {
        dragged = !dragged;
    }
}
