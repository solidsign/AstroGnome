using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackCooldown;

    public float Speed => speed;
    public float AttackDistance => attackDistance;
    public float AttackCooldown => attackCooldown;
}
