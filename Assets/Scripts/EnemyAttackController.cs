using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [Header("EnemyAttack")]
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject projectilePf;
    [SerializeField] private float enemyAttackSpeed;

    private float attackTimer;
    private bool canAttack;

    private void Start()
    {
        attackTimer = 0;
        canAttack = false;
    }

    private void Update()
    {
        EnemyAttack();
    }

    private void EnemyAttack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer > enemyAttackSpeed)
        {
            canAttack = true;
        }

        if (canAttack)
        {
            Instantiate(projectilePf, shootPoint.position, Quaternion.identity);

            canAttack = false;

            attackTimer = 0f;
        }
    }
}
