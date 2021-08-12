using UnityEngine;

public class WeaponEvents : MonoBehaviour
{
    [SerializeField] private float meleeAttackRadius;
    [SerializeField] private float basicDamage;
    [SerializeField] private float comboMultiplier;
    private Crosshair crosshair;
    private Animator animator;
    private ComboHandler combo;

    private void Start()
    {
        animator = GetComponent<Animator>();
        combo = GetComponent<ComboHandler>();
        crosshair = GetComponent<Crosshair>();
    }

    public void MeleeAxeHit()
    {
        var colliders = Physics2D.OverlapCircleAll(crosshair.AttackPoint, meleeAttackRadius);
        foreach (var collider in colliders)
        {
            if (!collider.CompareTag("Player"))
            {
                EnemyHealth enemy;
                if(collider.TryGetComponent<EnemyHealth>(out enemy))
                {
                    enemy.DealDamage(collider.transform.position - crosshair.AttackPoint, basicDamage * Mathf.Pow(comboMultiplier, combo.Combo));
                }
            }
        }
    }

}
