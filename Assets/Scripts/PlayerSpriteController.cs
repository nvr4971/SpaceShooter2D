using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer shipShieldSpriteRenderer;
    [SerializeField] private SpriteRenderer shipDamagedSpriteRenderer;

    [Header("Sprites")]
    [SerializeField] private List<Sprite> shipShieldSprites;
    [SerializeField] private List<Sprite> shipDamagedSprites;

    public void LoadSprites(List<Sprite> shieldSprites, List<Sprite> damagedSprites)
    {
        shipShieldSprites = shieldSprites;
        shipDamagedSprites = damagedSprites;
    }

    public void UpdateShieldSprite(int shield)
    {
        shipShieldSpriteRenderer.sprite = shield switch
        {
            1 => shipShieldSprites[0],
            2 => shipShieldSprites[1],
            3 => shipShieldSprites[2],
            _ => null
        };
    }

    public void UpdateDamagedSprite(int health)
    {
        shipDamagedSpriteRenderer.sprite = health switch
        {
            3 => shipDamagedSprites[0],
            2 => shipDamagedSprites[1],
            1 => shipDamagedSprites[2],
            _ => null
        };
    }
}
