using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cheat", menuName = "Cheat Code")]
public class Cheat : ScriptableObject
{
    [SerializeField] private List<KeyCode> keys;

    public List<KeyCode> Keys => keys;
}
