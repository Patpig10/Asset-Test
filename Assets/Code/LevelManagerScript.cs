using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Animalpen()
    {
        SceneManager.LoadScene(1);
    }

    public void Barn()
    {
        SceneManager.LoadScene(2);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void River()
    {
        SceneManager.LoadScene(3);
    }

    public void Mech()
    {
        SceneManager.LoadScene(4);
    }
    
}
