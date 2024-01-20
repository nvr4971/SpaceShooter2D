using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/PlayerShipSprites")]
public class PlayerShipSprites : ScriptableObject
{
    [Header("Player UI Sprites")]
    public Sprite playerUISprite;

    [Header("Player In-Game Sprites")]
    public Sprite playerInGameSprite;

    [Header("Player Projectiles Prefabs")]
    public List<GameObject> playerProjectilesSprites;

    [Header("Player Damaged Sprites Reference")]
    public List<Sprite> playerDamagedSprites;

    [Header("Shield Sprites")]
    public List<Sprite> shieldSprites;
}