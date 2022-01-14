using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class CardSpawner : MonoBehaviour
{
	[SerializeField] private float _cardSize;
	[SerializeField] private CardView _cardViewPrefab;
	[SerializeField] private GameEvent SessionFinishedEvent;
	[SerializeField] private UnityEvent<string, bool> TargetCardTextViewEvent; 

	private void OnEnable() => SessionFinishedEvent.AddListener(Clear);
	private void OnDisable() => SessionFinishedEvent.RemoveListener(Clear);

	private List<CardView> _currentCards = new List<CardView>();

	public void Spawn(UnityAction<CardView> cardViewAction, LevelData levelData, bool appear)
	{
		Clear();
		
		var positions = GetPositions(levelData.GridData.Raws, levelData.GridData.Lines);

		foreach (var cardData in levelData.Cards)
		{
			Vector2 position = positions.Random();
			CardView cardView = Instantiate(_cardViewPrefab, position, Quaternion.identity, transform);

			cardView.SetData(cardViewAction, cardData);
			
			if (appear)
				cardView.Appear();

			_currentCards.Add(cardView);
			positions.Remove(position);
		}

		TargetCardTextViewEvent.Invoke(levelData.TargetCard.Identifier, appear);
	}

	private void Clear()
	{
		foreach (var card in _currentCards)
			Destroy(card.gameObject);

		_currentCards.Clear();
	}

	public List<Vector2> GetPositions(int raws, int lines)
	{
		var positions = new List<Vector2>();

		var offset = new Vector2(raws, lines) - Vector2.one;

		for (int x = 0; x < raws; x++)
		{
			for (int y = 0; y < lines; y++)
			{
				var currentPosition = _cardSize * (new Vector2(x, y) - offset / 2f);
				positions.Add(currentPosition);
			}
		}

		return positions;
	}
}

