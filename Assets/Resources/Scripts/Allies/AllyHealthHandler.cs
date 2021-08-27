using UnityEngine;

public class AllyHealthHandler : HealthHandler
{
    private AudioHandler audioHandler;
    public EnemyManager Enemies { get; set; }
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        disabler = GetComponent<ComponentsDisabler>();
        audioHandler = GetComponent<AudioHandler>(); ;
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
        audioHandler.PlaySound("Damaged");
    }

    private void Die()
    {
        Enemies.DeletePlayersObject(transform);
        dead = true;
        animator.SetTrigger("Dead");
        audioHandler.PlaySound("Death");
    }
}
