using System.Collections;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    private Color currentColor;
    private Color colorWithIntensivity;
    private float currentIntensivity;
    [SerializeField] private float startIntensivity = 1.5f;
    [SerializeField] private float intensivityMultipliyer = 1.1f;
    [SerializeField] private Material material;
    [SerializeField] private float colorChangeSpeed;

    private void Start()
    {
        currentIntensivity = startIntensivity;
        currentColor = GetComponent<WeaponHandler>().Weapons[0].Color;
        material.SetColor("_color", currentColor * currentIntensivity);
    }


    public void SwitchColor(Color newColor)
    {
        StopCoroutine(LerpColor());
        currentColor = newColor;
        colorWithIntensivity = currentColor * currentIntensivity;
        StartCoroutine(LerpColor());
    }

    public void IncreaseIntensity()
    {
        currentIntensivity *= intensivityMultipliyer;
        SwitchColor(currentColor);
    }

    public void ResetIntensity()
    {
        currentIntensivity = 1f;
        SwitchColor(currentColor);
    }

    private IEnumerator LerpColor()
    {
        while(material.GetColor("_color") != colorWithIntensivity)
        {
            Color newColor = Color.Lerp(material.GetColor("_color"), colorWithIntensivity, colorChangeSpeed * Time.deltaTime);

            material.SetColor("_color", newColor);

            yield return null;
        }
    }

    // TODO: сделать норм интенсивность цвета
}
