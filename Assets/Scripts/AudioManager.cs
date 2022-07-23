using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Allows music Control to be accessed everywhere using "AudioManager.AM".
    public static AudioManager AM
    {
        get
        {
            if (s_instance == null)
            {
                new GameObject("AudioManager", typeof(AudioManager));
            }
            return s_instance;
        }
    }

    [Header("Music Settings")]
    [SerializeField] private string MusicTransitionParameterName = "MusicTransition";
    [SerializeField] [FMODUnity.EventRef] string music = "event:/Music";

    [Header("Atmos Settings")]
    [SerializeField] private string AtmosTransitionParameterName = "AtmosTransition";
    [SerializeField] [FMODUnity.EventRef] string atmos = "event:/Atmos";

    [Header("Button Audio Events")]
    [SerializeField] [FMODUnity.EventRef] string ButtonSelect = "event:/ButtonSelect";   
    [SerializeField] [FMODUnity.EventRef] string ButtonAccept = "event:/ButtonAccept";   
    //[SerializeField] [FMODUnity.EventRef] string ButtonDecline = "event:/ButtonDecline";  
    
    FMOD.Studio.EventInstance musicEV;
    FMOD.Studio.EventInstance atmosEV;

    private static AudioManager s_instance;

    

    void Awake()
    {
        if (s_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            s_instance = this;
        }
        else if (AM != this)
        {
            Destroy(gameObject);
            Debug.Log("AN AUDIO MANAGER WAS FUCKING KILLED");
        }
    }

    void Start()
    {
        musicEV = FMODUnity.RuntimeManager.CreateInstance(music);
        atmosEV = FMODUnity.RuntimeManager.CreateInstance(atmos);
        atmosEV.start();
    }

    public void SetMusicTransition(float transitionValue)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(MusicTransitionParameterName, transitionValue);
        Debug.Log("TransitionParamChange");
    }

    public void PlaySelectSound() 
    {
        FMODUnity.RuntimeManager.PlayOneShot(ButtonSelect);
    }

    public void PlayAcceptSound() 
    {
        FMODUnity.RuntimeManager.PlayOneShot(ButtonAccept);
    }

    //public void PlayDeclineSound() 
    //{
    //    FMODUnity.RuntimeManager.PlayOneShot(ButtonDecline);
    //}

    public void StartMusic()
    {
        musicEV.start();
    }

    //public void AtmosTransition()
    //{
    //    musicEV.start();
    //}

}
