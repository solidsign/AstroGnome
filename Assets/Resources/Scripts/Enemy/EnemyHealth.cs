using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hp;
    private Animator animator;
    private ComponentsDisabler components;
    private bool dead = false;
    private EnemyController controller;
    private AudioHandler audioHandler;

    private void Start()
    {
        animator = GetComponent<Animator>();
        components = GetComponent<ComponentsDisabler>();
        controller = GetComponent<EnemyController>();
        audioHandler = GetComponent<EditableAudioHandler>();
    }

    public bool DealDamage(float damage)
    {
        if (dead) return true;
        hp -= damage;
        if(hp <= 0)
        {
            Die();
            return true;
        }
        animator.SetTrigger("Damaged");
        audioHandler.PlaySound("Damaged");
        return false;
    }

    private void Die()
    {
        audioHandler.PlaySound("Death");
        components.DisableComponents();
        animator.SetTrigger("Dead");
        dead = true;
        controller.DieCallToManager();
    }
}
