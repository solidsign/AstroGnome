using UnityEngine;

public class WeaponEvents : MonoBehaviour
{
    [SerializeField] private float meleeAttackRadius;

    private Animator animator;
    private ComboHandler combo;

    private void Start()
    {
        animator = GetComponent<Animator>();
        combo = GetComponent<ComboHandler>();
    }
    public void MeleeAxeHit()
    {
        animator.SetTrigger("Hit");
    }
    public void DealMeleeDamage()
    {

    }


    private void OnDrawGizmosSelected()
    {
        
    }
}
