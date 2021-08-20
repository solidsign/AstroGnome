using UnityEngine;

public class ComboHandler : MonoBehaviour
{
    private int combo = 0;
    private ColorSwitcher color;
    private int minCombo = 0;

    public int Combo => combo;

    private void Start()
    {
        color = GetComponent<ColorSwitcher>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            IncreaseCombo();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            ResetCombo();
        }
    }

    public void AbsoluteComboReset()
    {
        combo = -100;
        color.IncreaseIntensity(combo);
        minCombo = -100;
    }

    public void IncreaseCombo()
    {
        ++combo;
        color.IncreaseIntensity(combo);
    }

    public void ResetCombo()
    {
        combo = minCombo;
        color.ResetIntensity();
    }

    public void IncreaseMinCombo()
    {
        minCombo += 3;
        if(combo < minCombo)
        {
            combo = minCombo;
            color.IncreaseIntensity(combo);
        }
    }

    public void DecreaseMinCombo()
    {
        minCombo -= 3;
        if (combo < minCombo)
        {
            combo = minCombo;
            color.IncreaseIntensity(combo);
        }
    }
}
