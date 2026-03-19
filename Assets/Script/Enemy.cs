using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Enemy : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int maxHP = 30;
    public GameObject highlight;
    public int health = 30;
    public int attackDamage = 5;
    public TextMeshProUGUI hpText;
    public Image hpBarFill;

    Player player;


    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy HP : " + health);

        if (health <= 0)
        {
            Debug.Log("Enemy Dead");
            Die();
        }

        health -= damage;
        UpdateHP();

        health -= damage;
        if (health < 0) health = 0;

        UpdateHPBar();
    }

    void UpdateHPBar()
    {
        float ratio = (float)health / maxHP;
        hpBarFill.fillAmount = ratio;
    }

    public void Attack()
    {
        int damage = 5;

        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Debug.Log("Enemy attacks!");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Card.isDragging)
            highlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.SetActive(false);
    }

    void Start()
    {
        UpdateHP();
        player = FindObjectOfType<Player>();
    }


    void UpdateHP()
    {
        hpText.text = "HP : " + health;
    }

    void Die()
    {
        GameManager.Instance.Victory();
        gameObject.SetActive(false);
    }
}