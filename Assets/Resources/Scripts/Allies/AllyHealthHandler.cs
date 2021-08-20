using UnityEngine;

public class AllyHealthHandler : HealthHandler
{
    private void Start()
    {
        animator = GetComponent<Animator>();
        disabler = GetComponent<ComponentsDisabler>();
    }

    public override void DealDamage(float damage)
    {
        if (dead) return;
        hp -= damage;
        if(hp <= 0f)
        {
            Die();
            return;
        }
        animator.SetTrigger("Damaged");
    }

    private void Die()
    {
        dead = true;
        disabler.DisableComponents();
        animator.SetTrigger("Dead");
    }
}
