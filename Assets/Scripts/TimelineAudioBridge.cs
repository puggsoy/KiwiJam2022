using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineAudioBridge : MonoBehaviour
{
    public void StartMusic()
    {
        AudioManager.AM.StartMusic();
    }
    

    public void AtmosTransition(float Param)
    {
        //AudioManager.AM.StartAtmos();
    }
}
