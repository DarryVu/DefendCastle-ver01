using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAlliance : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask enemyLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private HealthEnemy healthEnemy;
    private EnemyPatrol patrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        healthEnemy = GetComponent<HealthEnemy>();
        patrol = GetComponent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(InSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("MeleeAttack");
            }
        }
        if (patrol != null)
            patrol.enabled = !InSight();
    }

    private bool InSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);
        if (hit.collider != null)
            healthEnemy = hit.transform.GetComponent<HealthEnemy>();
        return hit.collider != null;
    }

    private void DamageEnemy()
    {
        if (InSight())
            healthEnemy.TakeDamage(damage);
    }


}
