using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float meleeAttackRadius;
    [SerializeField] private float meleeDamage;
    [SerializeField] private string attackAnimationTrigger = "Attack";

    public float Speed => speed;
    public float AttackDistance => attackDistance;
    public float AttackCooldown => attackCooldown;
    public float MeleeDamage => meleeDamage;
    public float MeleeAttackRadius => meleeAttackRadius;
    public string AttackAnimationTrigger => attackAnimationTrigger;
}
