using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Stats")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileLifetime;
    [SerializeField] private int projectilePower;

    [Header("Is Enemy Projectile?")]
    [SerializeField] private bool isEnemy;

    private Rigidbody2D rb;
    private Vector2 projectileDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        projectileDirection = isEnemy ? Vector2.down : Vector2.up;

        Destroy(gameObject, projectileLifetime);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (projectileSpeed * Time.fixedDeltaTime * projectileDirection));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle attack collision - TODO
    }

    public int GetProjectileDamage()
    {
        return projectilePower;
    }
}
