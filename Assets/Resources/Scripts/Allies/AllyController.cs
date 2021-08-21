using System.Collections;
using UnityEngine;

public class AllyController : MonoBehaviour
{
    private EnemyManager enemies;
    public EnemyManager Enemies { set => enemies = value; }

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float cooldown;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDistance;
    [SerializeField] private Transform attackPoint;
    private Transform attackPurpose;
    private Rigidbody2D rb;
    private Animator animator;
    private bool cooldownEnded = true;

    private void Start()
    {
        attackPurpose = enemies.GetRandomAliveEnemy();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(ComeForAttack());
    }

    private IEnumerator ComeForAttack()
    {
        while(Vector3.Distance(attackPurpose.position, transform.position) > attackDistance)
        {
            Vector3 moveDirection = attackPurpose.position - transform.position;
            moveDirection = moveDirection.normalized;
            rb.MovePosition(transform.position + speed * Time.deltaTime * moveDirection);
            yield return null;
        }
        animator.SetTrigger("Attack");
        StartCoroutine(CooldownTimer());
    }

    private IEnumerator MoveInRandomDirectionWhileCooldown()
    {
        Vector3 moveDirection = attackPurpose.position - transform.position;
        moveDirection = moveDirection.normalized;
        moveDirection += Random.Range(-1f, 1f) * transform.up + Random.Range(-1f, 1f) * transform.right;
        moveDirection = moveDirection.normalized;
        while (!cooldownEnded)
        {
            rb.MovePosition(transform.position + speed * Time.deltaTime * moveDirection);
            yield return null;
        }
    }

    private IEnumerator CooldownTimer()
    {
        cooldownEnded = false;
        StartCoroutine(MoveInRandomDirectionWhileCooldown());
        yield return new WaitForSeconds(cooldown);
        cooldownEnded = true;
        StartCoroutine(ComeForAttack());
    }

    public void MeleeAttack()
    {
        var colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

        foreach (var collider in colliders)
        {
            EnemyHealth enemy;
            if(collider.TryGetComponent<EnemyHealth>(out enemy))
            {
                if (enemy.DealDamage(damage))
                {
                    attackPurpose = enemies.GetRandomAliveEnemy();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackDistance);
    }
}
