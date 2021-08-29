using System.Collections;
using UnityEngine;

public class CheatFunctions : MonoBehaviour
{
    [SerializeField] private HealthHandler hp;
    [SerializeField] private ComboHandler combo;

    public void Hesoyam()
    {
        hp.RestoreHPFull();
        PlayerPrefs.SetInt("Hesoyam", PlayerPrefs.GetInt("Hesoyam", 0) + 1);
    }

    public void GodMod()
    {
        hp.RestoreHPFull();
        hp.GodMod();
        PlayerPrefs.SetInt("tgm", PlayerPrefs.GetInt("tgm", 0) + 1);
    }

    public void Konami()
    {
        StartCoroutine(IncreaseCombo());
        PlayerPrefs.SetInt("konami", PlayerPrefs.GetInt("konami", 0) + 1);
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
        PlayerPrefs.SetInt("iddqd", PlayerPrefs.GetInt("iddqd", 0) + 1);
    }


    public void IDKFA()
    {
        combo.AbsoluteComboReset();
        PlayerPrefs.SetInt("idkfa", PlayerPrefs.GetInt("idkfa", 0) + 1);
    }

    public void Noclip()
    {
        var colliders = combo.GetComponents<BoxCollider2D>();
        foreach (var collider in colliders)
        {
            collider.enabled = !collider.enabled;
        }
        PlayerPrefs.SetInt("noclip", PlayerPrefs.GetInt("noclip", 0) + 1);
    }
}
