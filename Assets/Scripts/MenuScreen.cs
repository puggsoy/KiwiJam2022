using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
	[SerializeField]
	private GameObject m_intructionsPrefab = null;

    //public void OnStartClick()
    //{
    //    Invoke("StartGame", 0.4f);
    //}


    //public void StartGame()
	//{
	//	SceneManager.LoadScene("GameScene");
	//}

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

	public void OpenInstructions()
	{
		m_intructionsPrefab.SetActive(true);
	}

	public void CloseInstructions()
	{
		m_intructionsPrefab.SetActive(false);
	}
}
