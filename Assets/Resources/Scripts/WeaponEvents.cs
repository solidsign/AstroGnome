using UnityEngine;

public class WeaponEvents : MonoBehaviour
{
    [SerializeField] private float meleeAttackRadius;
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
            Debug.Log(collider.name);
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(crosshair.AttackPoint, meleeAttackRadius);
    //}
}
