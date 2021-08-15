using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy data;
    private Transform attackPurpose;
    private MovementHandler movement;
    private AttackHandler attacker;

    public Transform AttackPurpose { set => attackPurpose = value; }


}
