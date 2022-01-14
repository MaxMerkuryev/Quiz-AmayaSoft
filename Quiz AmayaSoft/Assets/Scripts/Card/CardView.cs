using UnityEngine;
using UnityEngine.Events;

public class CardView : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _innerSpriteRenderer;

	[SerializeField] private UnityEvent RightAnswerEvent;
	[SerializeField] private UnityEvent WrongAnswerEvent;

	[SerializeField] private UnityEvent AppearEvent;

	private string _identifier;
	private UnityAction<CardView> _cardViewAction;

	public string Identifier => _identifier;

	public void Appear() => AppearEvent.Invoke();

	public void SetData(UnityAction<CardView> cardViewAction, CardData cardData)
	{
		_cardViewAction = cardViewAction;
		_identifier = cardData.Identifier;
		_innerSpriteRenderer.sprite = cardData.Sprite;
	}

	public void RightAnswer() => RightAnswerEvent.Invoke();
	public void WrongAnswer() => WrongAnswerEvent.Invoke();

	private void OnMouseDown() => _cardViewAction.Invoke(this);
}