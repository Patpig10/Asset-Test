using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollectorManager : MonoBehaviour
{
    public int fullitems = 0;
    int items = 0;
    public UnityEvent AllCollected;
    
    public void CollectItem()
    {
        items++;
        if(items == fullitems)
        {
            Completed();
        }
    }

    void Completed()
    {
        AllCollected.Invoke();
    }


}
