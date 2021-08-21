using UnityEngine;

public class AllyHealthHandler : HealthHandler
{
    public EnemyManager Enemies { get; set; }
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
        Enemies.DeletePlayersObject(transform);
        dead = true;
        animator.SetTrigger("Dead");
        disabler.DisableComponents();
    }
}
