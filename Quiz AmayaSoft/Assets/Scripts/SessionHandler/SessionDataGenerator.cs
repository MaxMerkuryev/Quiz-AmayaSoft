using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SessionDataGenerator : MonoBehaviour
{
	[SerializeField] private CardBundleData[] _cardBundleData;
	[SerializeField] private GridData[] _gridData;

	public LevelData[] GenerateSessionData()
	{
		List<LevelData> sessionData = new List<LevelData>();
		List<CardData> sessionTargets = new List<CardData>();

		var currentSessionBundle = _cardBundleData[Random.Range(0, _cardBundleData.Length)];

		foreach (var grid in _gridData)
		{
			LevelData levelData = GenerateLevel(currentSessionBundle.CardData.ToList(), grid, sessionTargets);

			sessionData.Add(levelData);
			sessionTargets.Add(levelData.TargetCard);
		}

		return sessionData.ToArray();
	}

	private LevelData GenerateLevel(List<CardData> cardData, GridData gridData, List<CardData> sessionTargets)
	{
		var generatedLevelCards = new List<CardData>();
		var targetCard = cardData.Except(sessionTargets).ToList().Random();

		generatedLevelCards.Add(targetCard);

		for (int i = 0; i < gridData.CardsCount - 1; i++)
		{
			var nextCard = cardData.Where(x => x != targetCard).ToList().Random();
			generatedLevelCards.Add(nextCard);
		}

		return new LevelData(gridData, generatedLevelCards, targetCard);
	}
}
