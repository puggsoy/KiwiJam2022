using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameObject : MonoBehaviour
{
	private readonly Dictionary<CardDefinition.CardType, Color> TypeToColor = new Dictionary<CardDefinition.CardType, Color>()
	{
		{ CardDefinition.CardType.Triangle, new Color(0.231f, 0.604f, 0.694f)},
		{ CardDefinition.CardType.Circle, new Color(0.863f, 0.322f, 0.290f) },
		{ CardDefinition.CardType.Square, new Color(0.325f, 0.745f, 0.424f) },
		{ CardDefinition.CardType.None, new Color(0.749f, 0.561f, 0.694f) },
	};

	[SerializeField]
	private Image m_image = null;

	[SerializeField]
	private Text m_text = null;

	private int m_cardId = -1;

	//========================================

	public void Init(Card card)
	{
		if (card == null)
			m_cardId = -1;
		else
		{
			m_cardId = card.ID;
			m_text.text = card.Definition.Name;
			m_image.color = TypeToColor[card.Definition.Type];
		}

		gameObject.SetActive(m_cardId >= 0);
	}

	public void OnClick()
	{
		GameManager.Instance.SubmitCard(m_cardId);
	}
}
