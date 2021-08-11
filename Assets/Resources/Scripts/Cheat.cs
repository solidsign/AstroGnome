using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Cheat", menuName = "Cheat Code")]
public class Cheat : ScriptableObject
{
    [SerializeField] private List<KeyCode> keys;
    [SerializeField] private UnityEvent cheatEvent;

    public List<KeyCode> Keys => keys;
    public UnityEvent CheatEvent => cheatEvent;
}
