using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;

    [Header("For NonMelee enemies")]
    [SerializeField] private GameObjectsPool projectiles;

    private string animationTrigger;
    private Animator animator;

    private float attackRadius;
    private Vector2 attackDirection;
    private float damage;

    public string AnimationTrigger { set => animationTrigger = value; }
    public float AttackRadius { set => attackRadius = value; }
    private void Start()
    {
        animator = GetComponent<Animator>();
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
}
