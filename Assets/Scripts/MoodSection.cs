using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodSection : MonoBehaviour
{
	[SerializeField]
	private Text m_text = null;

	//========================================

	public void SetEffect(int multiplyValue, int addValue)
	{
		string effectString = "×";

		if (multiplyValue < 0)
			effectString += $"({multiplyValue})";
		else
			effectString += $"{multiplyValue}";

		if (addValue < 0)
			effectString += $" - {Mathf.Abs(addValue)}";
		else if (addValue > 0)
			effectString += $" + {addValue}";

		m_text.text = effectString;
	}
}
