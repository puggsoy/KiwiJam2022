using System.Collections.Generic;
using UnityEngine;

public class Deck
{
	private List<Card> m_cards = null;

	public int Size => m_cards.Count;

	//========================================

	public Deck(List<int> definitionIDs)
	{
		Init(definitionIDs);
	}

	public void Init(List<int> definitionIDs)
	{
		m_cards = new List<Card>();

		for (int i = 0; i < definitionIDs.Count; i++)
		{
			m_cards.Add(new Card(GameManager.Instance.CardDefinitions.GetFromID(definitionIDs[i])));
		}
	}

	public void Refill(List<Card> cards)
	{
		m_cards.AddRange(cards);
		Shuffle();
	}

	public void Shuffle()
	{
		for (int i = 0; i < m_cards.Count - 1; i++)
		{
			int k = Random.Range(i, m_cards.Count);
			Card temp = m_cards[i];
			m_cards[i] = m_cards[k];
			m_cards[k] = temp;
		}
	}

	public Card Draw()
	{
		if (m_cards.Count == 0)
			return null;

		Card c = m_cards[0];
		m_cards.RemoveAt(0);

		return c;
	}

	public string PrintIDs()
	{
		string ids = "";

		for (int i = 0; i < m_cards.Count; i++)
		{
			if (i > 0)
				ids += ", ";

			ids += m_cards[i].Definition.ID.ToString("00");
		}

		return ids;
	}
}
