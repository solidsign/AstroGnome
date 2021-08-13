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
