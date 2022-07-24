using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RobotDefinitions", menuName = "RobotDefinitions", order = 1)]
public class RobotDefinitions : ScriptableObject
{
	[SerializeField]
	private List<RobotDefinition> m_definitions = null;
	public List<RobotDefinition> Definitions => m_definitions;
}

[Serializable]
public class RobotDefinition
{
	[SerializeField]
	private List<RobotMood> m_moods = null;

	private int m_currentMoodIndex = 0;
	public RobotMood CurrentMood => m_moods[m_currentMoodIndex];

	//========================================

	public void CycleMood()
	{
		m_currentMoodIndex++;

		if (m_currentMoodIndex >= m_moods.Count)
			m_currentMoodIndex = 0;
	}
}

[Serializable]
public class RobotMood
{
	[SerializeField]
	private int m_triangleMultiplicationValue = 1;
	public int TriangleMultiplicationValue => m_triangleMultiplicationValue;

	[SerializeField]
	private int m_triangleAddValue = 0;
	public int TriangleAddValue => m_triangleAddValue;

	[Space]
	[SerializeField]
	private int m_circleMultiplicationValue = 1;
	public int CircleMultiplicationValue => m_circleMultiplicationValue;

	[SerializeField]
	private int m_circleAddValue = 0;
	public int CircleAddValue => m_circleAddValue;

	[Space]
	[SerializeField]
	private int m_squareMultiplicationValue = 1;
	public int SquareMultiplicationValue => m_squareMultiplicationValue;

	[SerializeField]
	private int m_squareAddValue = 0;
	public int SquareAddValue => m_squareAddValue;

	[SerializeField]
	private List<String> m_descriptions = null;
	public List<string> Descriptions => m_descriptions;
}
