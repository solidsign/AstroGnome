using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hp;
    private Rigidbody2D rb;
    private Animator animator;
    private ComponentsDisabler components;
    private bool dead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        components = GetComponent<ComponentsDisabler>();
    }

    public void DealDamage(Vector2 attackDirection, float damage)
    {
        if (hp <= 0f) return;
        hp -= damage;
        rb.AddForce(attackDirection.normalized * damage, ForceMode2D.Impulse);
        if(hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (dead) return;
        components.DisableComponents();
        animator.SetTrigger("Dead");
        dead = true;
    }
}
