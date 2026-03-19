using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    public int cost;
    public Sprite artwork;

    public CardEffect effect;
}