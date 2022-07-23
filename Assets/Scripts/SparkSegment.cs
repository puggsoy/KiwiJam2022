using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SparkSegment : MonoBehaviour
{
	[SerializeField]
	private Image m_image = null;

	//========================================

	public void Select()
	{
		m_image.color = Color.green;
	}

	public void Deselect()
	{
		m_image.color = Color.white;
	}
}
