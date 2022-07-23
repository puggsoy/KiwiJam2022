using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuitterMachine : MonoBehaviour
{
    private float downTime, upTime, pressTime = 0;
    public float countDown = 2.0f;
    private bool ready = false;
 
    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Escape) && ready == false) 
        {
            downTime = Time.time;
            pressTime = downTime + countDown;
            ready = true;
        }

        if (Input.GetKeyUp (KeyCode.Escape)) 
        {
            ready = false;
        }

        if (Time.time >= pressTime && ready == true) 
        {
            ready = false;
            Application.Quit();

            #if UNITY_EDITOR
		    Debug.LogWarning("Would quit in actual game executable");
            #endif
        }  
    }      
}
