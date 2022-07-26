using System.Collections.Generic;
using UnityEngine;

public class SparkBar : MonoBehaviour
{
	[SerializeField]
	private List<SparkSegment> m_segments = null;

	private int m_currentLevel = 0;
	public int Currentlevel => m_currentLevel;

	//========================================

	public void Init()
	{
		SetLevel(0);
	}

	public void SetLevel(int level)
	{
		if (level > 5)
			level = 5;

		if (level < -5) // Do something special here
			level = -5;

		if (m_currentLevel == level)
			return;

		int oldSegmentIndex = 5 - (m_currentLevel);
		m_segments[oldSegmentIndex].Deselect();

		int segmentIndex = 5 - (level);
		m_segments[segmentIndex].Select();

		m_currentLevel = level;
	}
}
