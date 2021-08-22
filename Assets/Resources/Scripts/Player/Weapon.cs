using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private Color color;
    [SerializeField] private string animationTrigger;
    [SerializeField] private float cooldown;
    [SerializeField] private string soundName;
    [Range(0f,1f)] [SerializeField] private float soundVolume;

    public string AnimationTrigger => animationTrigger;
    public Color Color => color;
    public float Cooldown => cooldown;
    public string SoundName => soundName;
    public float SoundVolume => soundVolume;
}
