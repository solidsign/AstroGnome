using System.Collections;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    private Color currentColor;
    private float currentIntensity;
    [SerializeField] private float defaultIntensity = 1.4f;
    [SerializeField] private float intensityIncreaseNumber = 0.1f;
    [SerializeField] private Material material;
    [SerializeField] private float colorChangeSpeed;

    private void Start()
    {
        currentIntensity = defaultIntensity;
        currentColor = GetComponent<WeaponHandler>().Weapons[0].Color;
        material.SetColor("_color", currentColor * currentIntensity);
    }
    public void SwitchColor(Color newColor)
    {
        StopCoroutine(LerpColor());
        currentColor = newColor * currentIntensity;
        StartCoroutine(LerpColor());
    }

    public void IncreaseIntensity()
    {
        currentIntensity += intensityIncreaseNumber;
        SwitchColor(currentColor);
    }

    private IEnumerator LerpColor()
    {
        while(material.GetColor("_color") != currentColor)
        {
            Color newColor = Color.Lerp(material.GetColor("_color"), currentColor, colorChangeSpeed * Time.deltaTime);

            material.SetColor("_color", newColor);

            yield return null;
        }
    }

    // TODO: сделать норм интенсивность цвета
}
