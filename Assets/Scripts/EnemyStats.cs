using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer enemyShieldSprite;

    [Header("Enemy Stats")]
    [SerializeField] private int health;
    [SerializeField] private int shield;

    [Header("Shield Sprites")]
    [SerializeField] private List<Sprite> shieldSprites;

    // Handling damage
    public void TakeDamage(int amount)
    {
        // Shield blocking before health
        if (shield > 0)
        {
            shield = (shield - amount) > 0 ? shield - amount : 0;

            UpdateShieldSprite();
        }
        else
        {
            health -= amount;

            if (health < 0)
            {
                // Enemy death handle
                OnEnemyDeath();
            }
        }
    }

    private void UpdateShieldSprite()
    {
        enemyShieldSprite.sprite = shield switch
        {
            1 => shieldSprites[0],
            2 => shieldSprites[1],
            3 => shieldSprites[2],
            _ => null
        };
    }

    private void OnEnemyDeath()
    {
        // TODO
    }
}
