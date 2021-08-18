using UnityEngine;

public class ShootWaveColorIntensity : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private Color color;
    static private bool colorSet = false;

    private void Start()
    {
        if (colorSet) return;
        material.SetColor("_color", color);
        colorSet = true;
    }
    public float Intensity
    {
        set => material.SetColor("_color", color * value);
    }
}
