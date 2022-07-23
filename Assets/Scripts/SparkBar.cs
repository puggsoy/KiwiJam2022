using System.Collections.Generic;
using UnityEngine;

public class SparkBar : MonoBehaviour
{
	[SerializeField]
	private List<SparkSegment> m_segments = null;

	private int currentLevel = 0;

	//========================================

	public void Init()
	{
		SetLevel(0);
	}

	public void SetLevel(int level)
	{
		if (currentLevel == level)
			return;

		int oldSegmentIndex = 5 - (currentLevel);
		m_segments[oldSegmentIndex].Deselect();

		int segmentIndex = 5 - (level);
		m_segments[segmentIndex].Select();

		currentLevel = level;
	}
}
