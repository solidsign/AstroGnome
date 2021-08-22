using System.Collections;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] protected float hp;
    protected ComponentsDisabler disabler;
    protected Animator animator;
    private ComboHandler combo;
    protected bool dead = false;
    public float HP => hp;


    public void RestoreHPFull()
    {
        hp = 100;
    }

    public void GodMod()
    {
        dead = !dead;
    }

    private void Start()
    {
        disabler = GetComponent<ComponentsDisabler>();
        animator = GetComponent<Animator>();
        combo = GetComponent<ComboHandler>();
    }
    virtual public void DealDamage(float damage)
    {
        if (dead) return;
        StopAllCoroutines();
        hp -= damage;
        combo.ResetCombo();
        if(hp <= 0f)
        {
            Die();
            return;
        }
        StartCoroutine(Heal());
    }

    private IEnumerator Heal()
    {
        yield return new WaitForSeconds(3f);
        while(hp < 100f)
        {
            hp = Mathf.Lerp(hp, 100f, 5f * Time.deltaTime);
            yield return null;
        }
    }

    private void Die()
    {
        dead = true;
        disabler.DisableComponents();
        animator.SetTrigger("Dead");
    }
}
