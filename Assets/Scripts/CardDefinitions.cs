using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDefinitions", menuName = "CardDefinitions", order = 1)]
public class CardDefinitions : ScriptableObject
{
	[SerializeField]
	private List<CardDefinition> m_definitions = null;
	public List<CardDefinition> Definitions => m_definitions;

	//========================================

	public CardDefinition GetFromID(int id)
	{
		return m_definitions.Find(x => x.ID == id);
	}
}

[Serializable]
public class CardDefinition
{
	[SerializeField]
	private int m_id = 0;
	public int ID => m_id;

	[SerializeField]
	private string m_name = null;
	public string Name => m_name;
}
