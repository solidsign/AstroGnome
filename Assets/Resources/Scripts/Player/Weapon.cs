using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private Color color;
    [SerializeField] private string animationTrigger;
    [SerializeField] private string soundName;
    [SerializeField] private float cooldown;
    public string AnimationTrigger => animationTrigger;
    public Color Color => color;
    public float Cooldown => cooldown;
    public string SoundName => soundName;
}
