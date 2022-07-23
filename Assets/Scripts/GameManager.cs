using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private static GameManager m_instance = null;
	public static GameManager Instance => m_instance;

	[SerializeField]
	private CardDefinitions m_cardDefinitions = null;
	public CardDefinitions CardDefinitions => m_cardDefinitions;

	[SerializeField]
	private Text m_handDescription = null;

	[SerializeField]
	private Text m_deckDescription = null;

	[Space]
	[SerializeField]
	private List<int> m_initialDeckDefinition = null;

	private List<int> m_currentDeckDefinition = null;

	private Deck m_deck = null;

	private List<Card> m_hand = null;

	//========================================

	private void Awake()
	{
		m_instance = this;
	}

	private void Start()
	{
		m_currentDeckDefinition = m_initialDeckDefinition;

		m_deck = new Deck(m_currentDeckDefinition);
		m_deck.Shuffle();

		m_hand = new List<Card>();
		m_hand.Add(m_deck.Draw());
		m_hand.Add(m_deck.Draw());
		m_hand.Add(m_deck.Draw());

		m_deckDescription.text = string.Format("Deck Size: {0}\nIDs: {1}", m_deck.Size.ToString(), m_deck.PrintIDs());
		m_handDescription.text = string.Format("Hand Size: {0}\nIDs: {1}", m_hand.Count.ToString(), PrintHandIDs());
	}

	private string PrintHandIDs()
	{
		string ids = "";

		for (int i = 0; i < m_hand.Count; i++)
		{
			if (i > 0)
				ids += ", ";

			ids += m_hand[i].Definition.ID.ToString("00");
		}

		return ids;
	}
}
