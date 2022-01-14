using System;
using UnityEngine;

[Serializable]
public struct GridData
{
	[SerializeField] private int _raws;
	[SerializeField] private int _lines;

	public int Raws => _raws;
	public int Lines => _lines;
	public int CardsCount => _raws * _lines;
}