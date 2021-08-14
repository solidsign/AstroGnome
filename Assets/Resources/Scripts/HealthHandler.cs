using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private float hp;
    private ComponentsDisabler disabler;
    private Animator animator;
    private ComboHandler combo;
    public float HP => hp;

    private void Start()
    {
        disabler = GetComponent<ComponentsDisabler>();
        animator = GetComponent<Animator>();
        combo = GetComponent<ComboHandler>();
    }
    public void DealDamage(float damage)
    {
        hp -= damage;
        combo.ResetCombo();
        if(hp <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        disabler.DisableComponents();
        animator.SetTrigger("Dead");
    }
}
