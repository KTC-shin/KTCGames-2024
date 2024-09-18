using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public void PauseGame()
    {
        if (Time.timeScale == 0)
        { 
            Time.timeScale = 1; 
        }

        else
        {
            Time.timeScale = 0;
        }
    }
}
