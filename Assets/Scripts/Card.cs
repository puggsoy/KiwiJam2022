using UnityEngine;

public class Card
{
	private static int s_idCounter = 0;

	private int m_id = -1;
	public int ID => m_id;

	private CardDefinition m_definition = null;
	public CardDefinition Definition => m_definition;

	//========================================

	public Card(CardDefinition definition)
	{
		m_id = s_idCounter++;

		m_definition = definition;
	}
}
