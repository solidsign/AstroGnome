using System.Collections;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    private Color currentColor;
    [SerializeField] private Material material;
    [SerializeField] private float colorChangeSpeed;

    public void SwitchColor(Color newColor)
    {
        StopCoroutine(LerpColor());
        currentColor = newColor;
        StartCoroutine(LerpColor());
    }

    private IEnumerator LerpColor()
    {
        while(material.GetColor("_color") != currentColor)
        {
            Color newColor = Color.Lerp(material.GetColor("_color"), currentColor, colorChangeSpeed * Time.deltaTime);

            material.SetColor("_color", newColor);

            return null;
        }
        return null;
    }
}
