using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private Color color;
    [SerializeField] private UnityEvent attackEvent;
    public UnityEvent AttackEvent => attackEvent;
    public Color Color => color;
}
