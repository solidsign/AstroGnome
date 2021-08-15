using UnityEngine;

public abstract class AttackHandler : MonoBehaviour
{
    protected float distance;
    protected float cooldown;
    public void SetValues(float distance, float cooldown)
    {
        this.distance = distance;
        this.cooldown = cooldown;
    }

    virtual public void Attack()
    {
        Debug.Log(name + " attacked");
    }
}
