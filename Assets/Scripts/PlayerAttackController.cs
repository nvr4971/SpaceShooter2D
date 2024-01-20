using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform shootPoint;

    [Header("PlayerAttack")]
    [SerializeField] private float playerAttackSpeed;
    [SerializeField] private GameObject playerProjectile;

    [Header("Player Projectiles")]
    [SerializeField] private List<GameObject> projectilePrefabs;

    private float attackTimer;
    private bool canAttack;

    private void Start()
    {
        attackTimer = 0;
        canAttack = false;
    }

    private void Update()
    {
        PlayerAttack();
    }

    private void PlayerAttack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer > playerAttackSpeed)
        {
            canAttack = true;
        }

        if (Input.GetKey(KeyCode.Mouse0) && canAttack)
        {
            Instantiate(playerProjectile, shootPoint.position, Quaternion.identity);

            canAttack = false;

            attackTimer = 0f;
        }
    }

    public void UpdatePlayerProjectile(int power)
    {
        playerProjectile = projectilePrefabs[power - 1];
    }

    public void LoadProjectileSprites(List<GameObject> projectiles)
    {
        projectilePrefabs = projectiles;
    }
}
