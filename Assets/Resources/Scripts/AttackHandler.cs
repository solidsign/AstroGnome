using UnityEngine;

public abstract class AttackHandler : MonoBehaviour
{
    virtual public void Attack(Vector2 direction, float damage)
    {
        Debug.Log(name + " attacked");
    }
}
