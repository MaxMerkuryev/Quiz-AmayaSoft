using System.Collections.Generic;

public struct LevelData
{
	private GridData _gridData;
	private List<CardData> _cards;
	private CardData _targetCard;

	public GridData GridData => _gridData;
	public List<CardData> Cards => _cards;
	public CardData TargetCard => _targetCard;

	public LevelData(GridData gridData, List<CardData> cards, CardData targetCard)
	{
		_gridData = gridData;
		_cards = cards;
		_targetCard = targetCard;
	}
}