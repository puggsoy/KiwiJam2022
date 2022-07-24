using System;
using System.Collections.Generic;
using UnityEngine;

public class CompleteOverlay : MonoBehaviour
{
	public event Action OnSuccess = null;
	public event Action OnFailure = null;

	[SerializeField]
	private GameObject m_successBG = null;

	[SerializeField]
	private GameObject m_5text = null;

	[SerializeField]
	private GameObject m_4text = null;

	[SerializeField]
	private GameObject m_failureText = null;

	private bool m_success = false;

	//========================================

	public void Show(int finalLevel)
	{
		gameObject.SetActive(true);

		m_success = finalLevel > 3;

		m_5text.SetActive(finalLevel == 5);
		m_4text.SetActive(finalLevel == 4);
		m_failureText.SetActive(finalLevel < 4);
	}

	public void OnClick()
	{
		gameObject.SetActive(false);

		if (m_success)
		{
			OnSuccess.Invoke();
		}
		else
		{
			OnFailure.Invoke();
		}
	}
}
