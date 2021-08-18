using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int activeWeapon;
    private int amountOfWeapons;
    private ColorSwitcher color;
    private WeaponHandler handler;
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
        handler = GetComponent<WeaponHandler>();
        amountOfWeapons = handler.Weapons.Count;
        color = GetComponent<ColorSwitcher>();
    }

    public void SwitchWeapon()
    {
        ++ActiveWeapon;
        color.SwitchColor(handler.Weapons[ActiveWeapon].Color);
    }
}
