using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool playerTurn = true;

    EnergyManager energyManager;
    Enemy enemy;

    DeckManager deckManager;
    HandManager handManager;

    void Start()
    {
        energyManager = FindObjectOfType<EnergyManager>();
        enemy = FindObjectOfType<Enemy>();

        deckManager = FindObjectOfType<DeckManager>();
        handManager = FindObjectOfType<HandManager>();

        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        playerTurn = true;

        Debug.Log("Player Turn");

        if (energyManager != null)
        {
            energyManager.StartTurn();
        }

        DrawCards(1);
    }

    public void EndPlayerTurn()
    {
        playerTurn = false;

        handManager.DiscardAll();

        Debug.Log("Enemy Turn");

        EnemyTurn();
    }

    void EnemyTurn()
    {
        if (enemy != null)
        {
            enemy.Attack();
        }

        Invoke("StartPlayerTurn", 1.5f);
    }

    void DrawCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CardData card = deckManager.Draw();

            if (card != null)
            {
                handManager.AddCard(card);
            }
        }
    }
}