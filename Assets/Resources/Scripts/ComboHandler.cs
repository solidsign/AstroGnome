using UnityEngine;

public class ComboHandler : MonoBehaviour
{
    private int combo = 0;
    private ColorSwitcher color;

    public int Combo => combo;

    private void Start()
    {
        color = GetComponent<ColorSwitcher>();
    }

    public void IncreaseCombo()
    {
        ++combo;
        color.IncreaseIntensity();
    }

    public void ResetCombo()
    {
        combo = 0;
        color.ResetIntensity();
    }
}
