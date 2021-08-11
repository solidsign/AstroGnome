using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] private float hp;
    private ComponentsDisabler disabler;
    private Animator animator;
    public float HP => hp;

    private void Start()
    {
        disabler = GetComponent<ComponentsDisabler>();
        animator = GetComponent<Animator>();
    }
    public void DealDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        disabler.DisableComponents();
        animator.SetBool("Dead", true);
    }
}
