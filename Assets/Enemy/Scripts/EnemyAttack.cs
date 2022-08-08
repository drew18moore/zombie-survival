using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Transform player;
    [SerializeField] LayerMask whatIsPlayer;

    [SerializeField] float attackDamage;
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] float attackRange;
    bool alreadyAttacked;

    bool playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        playerInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);
        if (playerInAttackRange)
            AttackPlayer();
    }

    void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            GameObject.Find("Player").GetComponent<PlayerHealthController>().Health -= attackDamage;
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
