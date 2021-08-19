using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hp;
    private Animator animator;
    private ComponentsDisabler components;
    private bool dead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        components = GetComponent<ComponentsDisabler>();
    }

    public void DealDamage(Vector2 attackDirection, float damage)
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
    }
}
