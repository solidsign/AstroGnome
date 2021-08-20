using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] protected float hp;
    protected ComponentsDisabler disabler;
    protected Animator animator;
    private ComboHandler combo;
    protected bool dead = false;
    public float HP => hp;

    private void Start()
    {
        disabler = GetComponent<ComponentsDisabler>();
        animator = GetComponent<Animator>();
        combo = GetComponent<ComboHandler>();
    }
    virtual public void DealDamage(float damage)
    {
        if (dead) return;
        hp -= damage;
        combo.ResetCombo();
        if(hp <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        dead = true;
        disabler.DisableComponents();
        animator.SetTrigger("Dead");
    }
}
