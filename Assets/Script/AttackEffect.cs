using UnityEngine;

[CreateAssetMenu(menuName = "Card Effects/Attack")]
public class AttackEffect : CardEffect
{
    public int damage = 5;

    public override void Execute()
    {
        Enemy enemy = FindObjectOfType<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}