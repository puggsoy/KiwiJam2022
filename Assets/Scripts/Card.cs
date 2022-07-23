using UnityEngine;

public class Card
{
	private CardDefinition m_definition = null;
	public CardDefinition Definition => m_definition;

	//========================================

	public Card(CardDefinition definition)
	{
		m_definition = definition;
	}
}
