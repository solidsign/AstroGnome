using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private Color color;
    [SerializeField] private UnityEvent attackEvent;
    [SerializeField] private float cooldown;
    public UnityEvent AttackEvent => attackEvent;
    public Color Color => color;
    public float Cooldown => cooldown;
}
