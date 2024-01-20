using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersSpriteLoader : MonoBehaviour
{
    [Header("Player Scriptable")]
    [SerializeField] private PlayerShipSprites scriptable;

    [Header("References")]
    [SerializeField] private Image playerUIImage;
    [SerializeField] private SpriteRenderer playerInGameSprite;

    [SerializeField] private PlayerSpriteController playerSpriteController;
    [SerializeField] private PlayerAttackController playerAttackController;

    private void Start()
    {
        playerUIImage.sprite = scriptable.playerUISprite;
        playerInGameSprite.sprite = scriptable.playerInGameSprite;
        playerSpriteController.LoadSprites(scriptable.shieldSprites, scriptable.playerDamagedSprites);
        playerAttackController.LoadProjectileSprites(scriptable.playerProjectilesSprites);
    }
}
