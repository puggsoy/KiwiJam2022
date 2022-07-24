using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorBridge : MonoBehaviour
{
    public void AnimationEnd()
    {
        SceneManager.LoadScene("GameScene");
    }
    
}
