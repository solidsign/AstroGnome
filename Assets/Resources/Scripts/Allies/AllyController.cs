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
    private bool moving = true;
    private bool attackAvailable = false;
    private Vector3 moveDirection = Vector3.zero;
    private bool facingRight = true;
    private AudioHandler audioHandler;

    private void Start()
    {
        attackPurpose = enemies.GetRandomAliveEnemy();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioHandler = GetComponent<AudioHandler>();
        GetComponent<AllyHealthHandler>().Enemies = enemies;
        StartCoroutine(ComeForAttack());
    }


    private void Update()
    {
        if (cooldownEnded)
        {

            if (Vector3.Distance(attackPurpose.position, transform.position) > attackDistance)
            {
                if (!moving) StartCoroutine(ComeForAttack());
            }
            else if (attackAvailable)
            {
                StartCoroutine(CooldownTimer());
                audioHandler.PlaySound("Attack");
                animator.SetTrigger("Attack");
                attackAvailable = false;
            }
        }
        else if (!moving)
        {
            StartCoroutine(MoveInRandomDirectionWhileCooldown());
        }
        if(!facingRight && moveDirection.x > 0f)
        {
            Flip();
        }
        else if(facingRight && moveDirection.x < 0f)
        {
            Flip();
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        animator.SetBool("Run", false);
        moving = false;
        attackAvailable = true;
    }

    private void OnEnable()
    {
        cooldownEnded = true;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private IEnumerator ComeForAttack()
    {
        moving = true;
        animator.SetBool("Run", true);
        while(Vector3.Distance(attackPurpose.position, transform.position) > attackDistance)
        {
            moveDirection = attackPurpose.position - transform.position;
            moveDirection = moveDirection.normalized;
            rb.MovePosition(transform.position + speed * Time.deltaTime * moveDirection);
            yield return null;
        }
        moving = false;
        moveDirection = Vector3.zero;
        attackAvailable = true;
        animator.SetBool("Run", false);
    }

    private IEnumerator MoveInRandomDirectionWhileCooldown()
    {
        moveDirection = attackPurpose.position - transform.position;
        moveDirection = moveDirection.normalized;
        moveDirection += Random.Range(-1f, 1f) * transform.up + Random.Range(-1f, 1f) * transform.right;
        moveDirection = moveDirection.normalized;
        animator.SetBool("Run", true);
        while (!cooldownEnded)
        {
            rb.MovePosition(transform.position + speed * Time.deltaTime * moveDirection);
            yield return null;
        }
        moveDirection = Vector3.zero;
        animator.SetBool("Run", false);
    }

    private IEnumerator CooldownTimer()
    {
        cooldownEnded = false;
        yield return new WaitForSeconds(cooldown);
        cooldownEnded = true;
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
