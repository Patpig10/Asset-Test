using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateanimate : MonoBehaviour
{
    public Animator anim;
  
    public void Open()
    {
        anim.SetTrigger("Close");
    }
    public void Fork()
    {
        anim.SetTrigger("Back");
    }

    // Update is called once per frame
   
}
