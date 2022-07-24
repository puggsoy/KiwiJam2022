using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameObject : MonoBehaviour
{
	[SerializeField]
	private Image m_image = null;

	[SerializeField]
	private Text m_text = null;

	[Space]
	[SerializeField]
	private Sprite m_triangleSprite = null;

	[SerializeField]
	private Sprite m_circleSprite = null;

	[SerializeField]
	private Sprite m_squareSprite = null;

	[SerializeField]
	private Sprite m_colourlessSprite = null;

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
			
			switch (card.Definition.Type)
			{
				case CardDefinition.CardType.Triangle:
					m_image.sprite = m_triangleSprite;
					break;
				case CardDefinition.CardType.Circle:
					m_image.sprite = m_circleSprite;
					break;
				case CardDefinition.CardType.Square:
					m_image.sprite = m_squareSprite;
					break;
				case CardDefinition.CardType.None:
					m_image.sprite = m_colourlessSprite;
					break;
			}
		}

		gameObject.SetActive(m_cardId >= 0);
	}

	public void OnClick()
	{
		GameManager.Instance.SubmitCard(m_cardId);
	}
}
