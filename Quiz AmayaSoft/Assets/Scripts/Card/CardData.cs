using UnityEngine;
using System;

[Serializable]
public struct CardData
{
    [SerializeField] private string _identifier;
    [SerializeField] private Sprite _sprite;

    public string Identifier => _identifier;
    public Sprite Sprite => _sprite;

    public static bool operator ==(CardData a, CardData b) => a.Identifier == b.Identifier;
    public static bool operator !=(CardData a, CardData b) => a.Identifier != b.Identifier;
}
