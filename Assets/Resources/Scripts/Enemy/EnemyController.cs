using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [Header("Attack")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRadius;
    [SerializeField] private float meleeDamage;
    [SerializeField] private string attackAnimationTrigger = "Attack";

    private MovementHandler movement;
    private AttackHandler attacker;
    private float cooldownTimer = 0f;
    private Transform attackPurpose;
    private bool moving = false;
    public Transform AttackPurpose
    {
        set => attackPurpose = value;
    }

    private void Start()
    {
        movement.Speed = speed;
        attacker.AnimationTrigger = attackAnimationTrigger;
        attacker.AttackRadius = attackRadius;
        attacker.AttackPoint = attackPoint;
    }

    private void Update()
    {
        if (cooldownTimer <= 0f)
        {
            if (!moving && Vector3.Distance(attackPurpose.position, transform.position) > attackDistance)
            {
                StartCoroutine(ComeCloserForAttack());
            }
            else
            {
                attacker.Attack(attackPurpose.position - transform.position, meleeDamage);
            }
        }
        else if(!moving)
        {
            StartCoroutine(MoveWhileCooldown());
        }
    }

    private IEnumerator ComeCloserForAttack()
    {
        moving = true;
        do
        {
            movement.Direction = attackPurpose.position - transform.position;
            yield return null;
        } while (Vector3.Distance(attackPurpose.position, transform.position) > attackDistance);
        movement.Direction = Vector2.zero;
        moving = false;
    }

    private IEnumerator MoveWhileCooldown()
    {
        moving = true;
        movement.Direction = Random.Range(-1f, 1f) * transform.up + Random.Range(-1f, 1f) * transform.right;
        do
        {
            yield return null;
        } while (cooldownTimer > 0f);
        movement.Direction = Vector2.zero;
        moving = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackDistance);
    }
}
