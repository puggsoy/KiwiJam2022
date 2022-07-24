using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameObject : MonoBehaviour
{

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
			m_image.color = CardDefinition.TypeToColor[card.Definition.Type];
		}

		gameObject.SetActive(m_cardId >= 0);
	}

	public void OnClick()
	{
		GameManager.Instance.SubmitCard(m_cardId);
	}
}
