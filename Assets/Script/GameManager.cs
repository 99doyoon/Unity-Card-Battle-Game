using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DeckManager deck;
    public HandManager hand;

    public GameObject gameOverUI;
    public GameObject victoryUI;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        CardData card = deck.Draw();

        if (card != null)
        {
            hand.AddCard(card);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverUI.SetActive(true);
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        victoryUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}