using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int activeWeapon;
    private int amountOfWeapons;
    private ColorSwitcher color;
    public int ActiveWeapon
    {
        get => activeWeapon;
        private set
        {
            if (value >= amountOfWeapons)
            {
                activeWeapon = 0;
            }
            else
            {
                activeWeapon = value;
            }
        }
    }

    private void Start()
    {
        WeaponHandler handler = GetComponent<WeaponHandler>();
        amountOfWeapons = handler.weapons.Count;
        colors = GetComponent<ColorSwitcher>();
    }
    public void SwitchWeapon()
    {
        ++ActiveWeapon;
    }
}
