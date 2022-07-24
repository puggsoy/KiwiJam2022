using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private int HAND_SIZE = 3;

	private static GameManager s_instance = null;
	public static GameManager Instance => s_instance;

	[SerializeField]
	private GameObject m_cardCanvas = null;

	[SerializeField]
	private CardDefinitions m_cardDefinitions = null;
	public CardDefinitions CardDefinitions => m_cardDefinitions;

	[SerializeField]
	private RobotDefinitions m_robotDefinitions = null;

	[SerializeField]
	private Text m_deckDescription = null;

	[SerializeField]
	private Text m_discardDescription = null;

	[SerializeField]
	private CardGameObject m_cardObj1 = null;

	[SerializeField]
	private CardGameObject m_cardObj2 = null;

	[SerializeField]
	private CardGameObject m_cardObj3 = null;

	[SerializeField]
	private SparkBar m_sparkBar = null;

	[SerializeField]
	private MoodsDisplay m_moodDisplay = null;

	[SerializeField]
	private CompleteOverlay m_completeOverlay = null;

	[Space]
	[SerializeField]
	private List<int> m_initialDeckDefinition = null;

	private List<int> m_currentDeckDefinition = null;

	private Deck m_deck = null;

	private List<Card> m_hand = null;

	private DiscardPile m_discardPile = null;

	private RobotDefinition m_currentRobot = null;

	private int m_currentRobotIndex = 0;

	//========================================

	private void Awake()
	{
		s_instance = this;
	}

	private void Start()
	{
		m_currentDeckDefinition = m_initialDeckDefinition;
		m_currentRobot = m_robotDefinitions.Definitions[m_currentRobotIndex];

		m_deck = new Deck(m_currentDeckDefinition);
		m_deck.Shuffle();
		m_hand = new List<Card>();
		m_discardPile = new DiscardPile();
		m_sparkBar.Init();

		m_completeOverlay.OnSuccess += GoToNextRobot;
		m_completeOverlay.OnFailure += Fail;

		RefillHand();
	}

	public void EnableGame()
	{
		m_cardCanvas.SetActive(true);

		Refresh();
	}

	public void Refresh()
	{
		m_deckDescription.text = string.Format("Deck Cards: {0}", m_deck.PrintIDs());
		m_discardDescription.text = string.Format("Discarded Cards: {0}", m_discardPile.PrintIDs());

		m_cardObj1.Init(m_hand[0]);
		m_cardObj2.Init(m_hand[1]);
		m_cardObj3.Init(m_hand[2]);

		m_moodDisplay.SetMood(m_currentRobot.CurrentMood);

		if (m_hand[0] == null && m_hand[1] == null && m_hand[2] == null)
		{
			m_completeOverlay.Show(m_sparkBar.Currentlevel);
		}
	}

	public void SubmitCard(int cardId)
	{
		Card card = m_hand.Find(x => x.ID == cardId);

		ResolveCard(card);

		m_hand.Remove(card);

		if (m_deck.Size + m_discardPile.Size + m_hand.Count <= 3)
		{
			m_discardPile.RefillDeck(m_deck);
			m_hand.Add(m_deck.Draw());
		}
		else
		{
			m_discardPile.Discard(m_hand);

			RefillHand();
		}

		m_currentRobot.CycleMood();

		Refresh();
	}

	private void RefillHand()
	{
		for (int i = 0; i < HAND_SIZE; i++)
		{
			if (m_deck.Size == 0)
			{
				m_discardPile.RefillDeck(m_deck);
			}

			m_hand.Add(m_deck.Draw());
		}
	}

	private void ResolveCard(Card card)
	{
		CardEffect effect = card.Definition.Effect;
		RobotMood mood = m_currentRobot.CurrentMood;
		int newLevel = m_sparkBar.Currentlevel;

		int amount = effect.Amount;
		
		switch (card.Definition.Type)
		{
			case CardDefinition.CardType.Triangle:
				amount *= mood.TriangleMultiplicationValue;
				amount += mood.TriangleAddValue;
				break;
			case CardDefinition.CardType.Circle:
				amount *= mood.CircleMultiplicationValue;
				amount += mood.CircleAddValue;
				break;
			case CardDefinition.CardType.Square:
				amount *= mood.SquareMultiplicationValue;
				amount += mood.SquareAddValue;
				break;
		}

		switch (effect.Operation)
		{
			case CardEffect.OperationType.Add:
				newLevel += amount;
				break;
			case CardEffect.OperationType.Subtract:
				newLevel -= amount;
				break;
			case CardEffect.OperationType.Multiply:
				if (card.Definition.Type != CardDefinition.CardType.None)
				{
					Debug.LogWarning("Multiplying with a colored card! Expect weird behaviour!");
				}

				newLevel *= amount;
				break;
		}

		m_sparkBar.SetLevel(newLevel);
	}

	private void GoToNextRobot()
	{
		if (m_currentRobotIndex == m_robotDefinitions.Definitions.Count - 1)
			Fail();

		m_currentRobot = m_robotDefinitions.Definitions[++m_currentRobotIndex];

		m_deck = new Deck(m_currentDeckDefinition);
		m_deck.Shuffle();
		m_hand = new List<Card>();
		m_discardPile = new DiscardPile();
		m_sparkBar.Init();

		RefillHand();
		Refresh();
	}

	private void Fail()
	{
		SceneManager.LoadScene("MenuScene");
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
