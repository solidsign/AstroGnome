﻿using UnityEngine;

public class AttackHandler : MonoBehaviour
{

    [Header("For NonMelee enemies")]
    [SerializeField] private GameObjectsPool projectiles;

    [Header("For spawners")]
    [SerializeField] private GameObject spawnObjectPrefab;

    private string animationTrigger;
    private Animator animator;

    private float attackRadius;
    private Vector2 attackDirection;
    private float damage;
    private Transform attackPoint;
    private EnemyController enemyController;

    public string AnimationTrigger { set => animationTrigger = value; }
    public float AttackRadius { set => attackRadius = value; }
    public Transform AttackPoint { set => attackPoint = value; }
    private void Start()
    {
        animator = GetComponent<Animator>();
        if(spawnObjectPrefab != null)
        {
            enemyController = GetComponent<EnemyController>();
        }
    }
    public void Attack(Vector2 direction, float damage)
    {
        this.damage = damage;
        attackDirection = direction;

        animator.SetTrigger(animationTrigger);
    }

    // Animation Events //

    public void ShootProjectile()
    {
        GameObject projectile = projectiles.GetObject();

        projectile.transform.position = attackPoint.position;
        projectile.transform.rotation = Quaternion.LookRotation(Vector3.forward, attackDirection);

        if (projectile.activeSelf)
        {
            projectile.SetActive(false);
        }
        projectile.SetActive(true);
    }

    public void MeleeAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, 8);
        
        foreach (var collider in colliders)
        {
            if(collider != null)
            {
                HealthHandler hp = collider.GetComponent<HealthHandler>();
                hp.DealDamage(damage);
            }
        }
    }

    public void SpawnFireTotems()
    {
        Vector3[] positions = new Vector3[4];

        positions[0] = attackPoint.position + transform.up * attackRadius;
        positions[1] = attackPoint.position - transform.up * attackRadius;
        positions[2] = attackPoint.position + transform.right * attackRadius;
        positions[3] = attackPoint.position - transform.right * attackRadius;

        for (int i = 0; i < 4; i++)
        {
            GameObject totem = Instantiate(spawnObjectPrefab);
            totem.transform.position = positions[i];
            totem.GetComponent<FireTotem>().AttackPurpose = enemyController.AttackPurpose;
        }
    }
}
