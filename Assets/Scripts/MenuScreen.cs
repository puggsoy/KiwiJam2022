using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public void OnStartClick()
    {
        Invoke("StartGame", 0.4f);
    }

    private void StartGame()
	{
		SceneManager.LoadScene("GameScene");
	}

    public void OnExitClick()
	{
		Invoke("ExitGame", 0.6f);
	}

    private void ExitGame()
	{
		Application.Quit();

    #if UNITY_EDITOR
		Debug.LogWarning("Would quit in actual game executable");
    #endif
	}
}
