using UnityEngine;
using UnityEngine.UIElements;
using Uno3D.Core;
[System.Serializable]
public class Card
{
    public CardColor Color;
    public CardValue Value;


    public Card(CardColor color, CardValue value)
    {
        this.Color = color;
        this.Value = value;
    }

    
}
