using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy data;
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
        movement.Speed = data.Speed;
    }

    private void Update()
    {
        if (cooldownTimer <= 0f)
        {
            if (!moving && Vector3.Distance(attackPurpose.position, transform.position) > data.AttackDistance)
            {
                StartCoroutine(ComeCloserForAttack());
            }
            else
            {
                attacker.Attack(attackPurpose.position - transform.position, data.MeleeDamage);
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
        } while (Vector3.Distance(attackPurpose.position, transform.position) > data.AttackDistance);
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
}
