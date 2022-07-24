using System.Collections.Generic;
using UnityEngine;

public class MoodsDisplay : MonoBehaviour
{
	[SerializeField]
	private MoodSection m_triangleMood = null;

	[SerializeField]
	private MoodSection m_circleMood = null;

	[SerializeField]
	private MoodSection m_squareMood = null;

	//========================================

	public void SetMood(RobotMood mood)
	{
		m_triangleMood.SetEffect(mood.TriangleMultiplicationValue, mood.TriangleAddValue);
		m_circleMood.SetEffect(mood.CircleMultiplicationValue, mood.CircleAddValue);
		m_squareMood.SetEffect(mood.SquareMultiplicationValue, mood.SquareAddValue);
	}
}
