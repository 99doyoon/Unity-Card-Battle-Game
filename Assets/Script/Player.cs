using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int maxHP = 50;
    public int currentHP;
    public TextMeshProUGUI hpText;

    void Start()
    {
        currentHP = maxHP;
        UpdateUI();
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP < 0)
            currentHP = 0;

        UpdateUI();

        if (currentHP == 0)
        {
            Die();
        }
    }

    void UpdateUI()
    {
        hpText.text = "HP: " + currentHP;
    }

    void Die()
    {
        Debug.Log("게임 오버!");
        GameManager.Instance.GameOver();
        // 나중에 UI 연결
    }
}