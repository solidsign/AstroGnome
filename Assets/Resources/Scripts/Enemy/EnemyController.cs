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
    private Animator animator;
    private float cooldownTimer = 0f;
    private Transform attackPurpose;
    private bool moving = false;
    private bool attackAvailable = true;
    private EnemyManager manager;
    public EnemyManager Manager { set => manager = value; }

    public void DieCallToManager()
    {
        manager.DeleteEnemyFromList(this);
    }
    public Transform AttackPurpose
    {
        get => attackPurpose;
        set => attackPurpose = value;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<MovementHandler>();
        attacker = GetComponent<AttackHandler>();
        movement.Speed = speed;
        attacker.AnimationTrigger = attackAnimationTrigger;
        attacker.AttackRadius = attackRadius;
        attacker.AttackPoint = attackPoint;
        if(attackPurpose == null)
        {
            attackPurpose = GameObject.FindGameObjectWithTag("Player").transform;
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
        StartCoroutine(CooldownTimer());
    }

    private void Update()
    {
        if (cooldownTimer <= 0f)
        {
            
            if (Vector3.Distance(attackPurpose.position, transform.position) > attackDistance)
            {
                if(!moving) StartCoroutine(ComeCloserForAttack());
            }
            else if(attackAvailable)
            {
                cooldownTimer = attackCooldown;
                StartCoroutine(CooldownTimer());
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
        attackAvailable = false;
        animator.SetBool("Run", true);
        do
        {
            movement.Direction = attackPurpose.position - transform.position;
            yield return null;
        } while (Vector3.Distance(attackPurpose.position, transform.position) > attackDistance);
        movement.Direction = Vector2.zero;
        animator.SetBool("Run", false);
        moving = false;
        attackAvailable = true;
    }

    private IEnumerator MoveWhileCooldown()
    {
        moving = true;
        animator.SetBool("Run", true);
        movement.Direction = Random.Range(-1f, 1f) * transform.up + Random.Range(-1f, 1f) * transform.right;
        do
        {
            yield return null;
        } while (cooldownTimer > 0f);
        movement.Direction = Vector2.zero;
        animator.SetBool("Run", false);
        moving = false;
    }

    private IEnumerator CooldownTimer()
    {
        while(cooldownTimer >= 0f)
        {
            cooldownTimer -= Time.deltaTime;
            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackDistance);
    }
}
