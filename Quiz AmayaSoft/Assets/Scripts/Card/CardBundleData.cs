using System;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data")]
public class CardBundleData : ScriptableObject
{
	[SerializeField] private CardData[] _cardData;

	public ReadOnlyCollection<CardData> CardData => Array.AsReadOnly(_cardData);
}