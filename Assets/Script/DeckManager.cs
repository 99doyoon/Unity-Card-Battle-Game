using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<CardData> discard = new List<CardData>();
    public List<CardData> deck = new List<CardData>();

    DiscardManager discardManager;

    void Start()
    {
        discardManager = FindObjectOfType<DiscardManager>();
    }

    public CardData Draw()
    {
        if (deck.Count == 0)
        {
            Reshuffle();
        }

        if (deck.Count == 0)
        {
            Debug.Log("No cards left to draw");
            return null;
        }

        CardData card = deck[0];
        deck.RemoveAt(0);

        return card;
    }

    void Reshuffle()
    {
        if (discardManager == null)
            return;

        deck.AddRange(discardManager.discardPile);
        discardManager.discardPile.Clear();

        Debug.Log("Deck Reshuffled");
    }

    void Shuffle(List<CardData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }
}