using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerSpriteController playerSpriteController;
    [SerializeField] private PlayerAttackController playerAttackController;

    [Header("Player Stats")]
    [SerializeField] private int health;
    [SerializeField] private int shield;
    [SerializeField] private int lives;
    [SerializeField] private int power;
    [SerializeField] private int score;

    private void Start()
    {
        InitiateStats();
    }

    private void InitiateStats()
    {
        health = 4;
        shield = 1;
        lives = 3;
        power = 1;
        score = 0;

        // Update UI
        UIManager.Instance.UpdateScoreUI(score);
        UIManager.Instance.UpdateLivesUI(lives);
        UIManager.Instance.UpdatePowerUI(power);
        UIManager.Instance.UpdateShieldUI(shield);

        // Update player sprites
        playerAttackController.UpdatePlayerProjectile(power);
        playerSpriteController.UpdateDamagedSprite(health);
        playerSpriteController.UpdateShieldSprite(shield);
    }

#region "Health and Shield, handling taking hits"
    // Health
    public void AddHealth(int amount)
    {
        if (health <= Constants.PLAYER_MIN_HEALTH || health >= Constants.PLAYER_MAX_HEALTH) return;

        health += amount;

        playerSpriteController.UpdateDamagedSprite(health);
    }

    public void RemoveHealth(int amount)
    {
        if (health <= Constants.PLAYER_MIN_HEALTH || health >= Constants.PLAYER_MAX_HEALTH) return;

        health -= amount;

        playerSpriteController.UpdateDamagedSprite(health);
    }

    // Shield
    public void AddShield(int amount)
    {
        if (shield <= Constants.SHIELD_MIN || shield >= Constants.SHIELD_MAX) return;

        shield += amount;

        UIManager.Instance.UpdateShieldUI(shield);
    }

    public void RemoveShield(int amount)
    {
        if (shield <= Constants.SHIELD_MIN || shield >= Constants.SHIELD_MAX) return;

        shield -= amount;

        UIManager.Instance.UpdateShieldUI(shield);
    }

    // Handling damage
    public void TakeDamage(int amount)
    {
        // Shield blocking before health
        if (shield > 0)
        {
            shield = (shield - amount) > 0 ? shield - amount : 0;

            UIManager.Instance.UpdateShieldUI(shield);
        }
        else
        {
            health -= amount;

            if (health < 0)
            {
                // Player Death handle
                OnPlayerDeath();
            }

            playerSpriteController.UpdateDamagedSprite(health);
        }
    }
    #endregion

#region "Lives"
    // Life
    public void AddLife(int amount)
    {
        if (lives <= Constants.PLAYER_LIVES_MIN) return;

        lives += amount;

        UIManager.Instance.UpdateLivesUI(lives);
    }

    public void RemoveLife(int amount)
    {
        if (lives <= Constants.PLAYER_LIVES_MIN) return;

        lives -= amount;

        UIManager.Instance.UpdateLivesUI(lives);
    }
    #endregion

#region "Power"
    // Power
    public void AddPower(int amount)
    {
        if (power <= Constants.PROJECTILE_POWER_MIN || power >= Constants.PROJECTILE_POWER_MAX) return;

        power += amount;

        UIManager.Instance.UpdatePowerUI(power);
        playerAttackController.UpdatePlayerProjectile(power);
    }

    public void ReducePower()
    {
        if (power <= 1 || power >= Constants.PROJECTILE_POWER_MAX) return;

        power /= 2;

        UIManager.Instance.UpdatePowerUI(power);
        playerAttackController.UpdatePlayerProjectile(power);
    }
#endregion

    private void OnPlayerDeath()
    {
        // Player explosion effect - TODO

        // Reduces power by half
        ReducePower();

        // Reduces life by 1
        RemoveLife(1);

        // Check GameOver
        if (lives == 0)
        {
            OnGameOver();
            return;
        }

        // Generates fresh player with 1 shield and full health
    }

    private void OnGameOver()
    {
        // TODO
    }
}
