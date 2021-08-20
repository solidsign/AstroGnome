using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hp;
    private Animator animator;
    private ComponentsDisabler components;
    private bool dead = false;
    private EnemyController controller;

    private void Start()
    {
        animator = GetComponent<Animator>();
        components = GetComponent<ComponentsDisabler>();
        controller = GetComponent<EnemyController>();
    }

    public void DealDamage(float damage)
    {
        if (dead) return;
        hp -= damage;
        if(hp <= 0)
        {
            Die();
            return;
        }
        animator.SetTrigger("Damaged");
    }

    private void Die()
    {
        components.DisableComponents();
        animator.SetTrigger("Dead");
        dead = true;
        controller.DieCallToManager();
    }
}
