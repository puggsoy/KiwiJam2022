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
	public enum CardType
	{
		Triangle,
		Circle,
		Square,
		None
	}

	[SerializeField]
	private int m_id = 0;
	public int ID => m_id;

	[SerializeField]
	private string m_name = null;
	public string Name => m_name;

	[SerializeField]
	private string m_description = null;
	public string Description => m_description;

	[SerializeField]
	private CardEffect m_effect = null;
	public CardEffect Effect => m_effect;

	[SerializeField]
	private CardType m_type = CardType.Triangle;
	public CardType Type => m_type;

	[SerializeField]
	private Sprite m_image = null;
	public Sprite Image => m_image;
}

[Serializable]
public class CardEffect
{
	public enum OperationType
	{
		Add,
		Subtract,
		Multiply
	}

	public OperationType Operation = OperationType.Add;

	public int Amount = 1;
}
