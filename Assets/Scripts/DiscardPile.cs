using System.Collections.Generic;
using UnityEngine;

public class DiscardPile
{
	private List<Card> m_cards = null;

	public int Size => m_cards.Count;

	//========================================

	public DiscardPile()
	{
		m_cards = new List<Card>();
	}

	public void Discard(List<Card> hand)
	{
		m_cards.AddRange(hand);
		hand.Clear();
	}

	public void RefillDeck(Deck deck)
	{
		deck.Refill(m_cards);
		m_cards.Clear();
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
