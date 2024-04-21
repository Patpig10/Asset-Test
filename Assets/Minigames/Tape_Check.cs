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
            rectTransform.localPosition.y < 50 && rectTransform.localPosition.y > 6 && !dragged)
        {
            StartCoroutine(Coroutine1());
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            dragged = true;
        }
        else
        {
            dragged = false;
        }
    }

    public void Dragging()
    {
        
    }

    IEnumerator Coroutine1()
    {
        yield return new WaitForSeconds(0.4f);
        fin.Invoke();
        finished = true;

    }
}
