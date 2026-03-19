using System.Collections.Generic;
using UnityEngine;

public class DiscardManager : MonoBehaviour
{
    public List<CardData> discardPile = new List<CardData>();

    public void AddToDiscard(CardData card)
    {
        discardPile.Add(card);
        Debug.Log("Discarded : " + card.cardName);
    }
}