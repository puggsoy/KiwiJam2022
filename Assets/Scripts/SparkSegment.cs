using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SparkSegment : MonoBehaviour
{
	[SerializeField]
	private GameObject m_onObject = null;
	[SerializeField]
	private GameObject m_offObject = null;

	//========================================

	public void Select()
	{
		m_onObject.SetActive(true);
		m_offObject.SetActive(false);
	}

	public void Deselect()
	{
		m_offObject.SetActive(true);
		m_onObject.SetActive(false);
	}
}
