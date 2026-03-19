using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public List<Card> discard = new List<Card>();

    public void DrawCard()
    {
        if (deck.Count == 0)
        {
            Reshuffle();
        }

        if (deck.Count == 0)
        {
            Debug.Log("No cards left");
            return;
        }

        Card card = deck[0];
        deck.RemoveAt(0);
        hand.Add(card);

        Debug.Log("Draw: " + card.name);
    }

    void Reshuffle()
    {
        Debug.Log("Reshuffling!");

        deck.AddRange(discard);
        discard.Clear();

        Shuffle(deck);
    }

    void Shuffle(List<Card> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }

    public void DiscardHand()
    {
        foreach (var card in hand)
        {
            discard.Add(card);
        }

        hand.Clear();
        Debug.Log("Hand discarded");
    }
}