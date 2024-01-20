using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer playerSprite;
    
    [Header("PlayerMove")]
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float spriteDiv;

    private Rigidbody2D rb;

    private Vector2 movementInput;
    private Vector2 cameraBounds;
    private float playerSpriteWidth;
    private float playerSpriteHeight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        cameraBounds = Camera.main.ScreenToWorldPoint(
            new Vector3 (
                Screen.width,
                Screen.height,
                Camera.main.transform.position.z
            )
        );

        playerSpriteWidth = playerSprite.bounds.size.x / 2f;
        playerSpriteHeight = playerSprite.bounds.size.y / 2f;
    }

    private void Update()
    {
        PlayerMove();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (playerMoveSpeed * Time.fixedDeltaTime * movementInput));
    }

    private void LateUpdate()
    {
        PlayerBounds();
    }

    private void PlayerBounds()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, cameraBounds.x * -1 + playerSpriteWidth, cameraBounds.x - playerSpriteWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, cameraBounds.y * -1 + playerSpriteHeight, cameraBounds.y - playerSpriteHeight);
        transform.position = viewPos;
    }

    private void PlayerMove()
    {
        movementInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
    }
}
