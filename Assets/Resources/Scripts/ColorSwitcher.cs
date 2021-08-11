using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    private Color currentColor;
    [SerializeField] private Material material;
    [SerializeField] private float colorChangeSpeed;

    private void Update()
    {
        
    }

    public void SwitchColor()
    {
        StopCoroutine(ChangeColor());
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
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
