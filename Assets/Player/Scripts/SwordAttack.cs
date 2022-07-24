using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] float damage = 50f;
    [SerializeField] Collider2D swordCollider;
    [SerializeField] PointsController pointsController;
    [SerializeField] float pointsOnHit = 100f;
    Vector2 rightAttackOffset;

    private void Start()
    {
        rightAttackOffset = transform.position;
        pointsController = GetComponentInParent<PointsController>();
    }

    public void AttackRight()
    {
        print("Attack RIGHT");
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        print("Attack LEFT");
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealthController enemy = other.GetComponent<EnemyHealthController>();
            if (enemy != null)
            {
                enemy.Health -= damage;
                pointsController.Points += pointsOnHit;
            }
        }
    }
}
