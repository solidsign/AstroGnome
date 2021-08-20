using System.Collections;
using UnityEngine;

public class CheatFunctions : MonoBehaviour
{
    [SerializeField] private HealthHandler hp;
    [SerializeField] private ComboHandler combo;


    public void Hesoyam()
    {
        hp.RestoreHPFull();
    }

    public void GodMod()
    {
        hp.RestoreHPFull();
        hp.GodMod();
    }

    public void Konami()
    {
        StartCoroutine(IncreaseCombo());
    }

    private IEnumerator IncreaseCombo()
    {
        for (int i = 0; i < 30; i++)
        {
            combo.IncreaseMinCombo();
            yield return null;
            yield return null;
        }
    }
}
