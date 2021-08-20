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
    public void IDDQD()
    {
        hp.DealDamage(1000f);
    }


    public void IDKFA()
    {
        combo.AbsoluteComboReset();
    }

    public void Noclip()
    {
        var colliders = combo.GetComponents<BoxCollider2D>();
        foreach (var collider in colliders)
        {
            collider.enabled = !collider.enabled;
        }
    }
}
