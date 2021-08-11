using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public List<Weapon> weapons;
    private WeaponSwitcher switcher;

    private void Start()
    {
        switcher = GetComponent<WeaponSwitcher>();
    }

    private void Update()
    {
        if (!Input.anyKeyDown)
        {
            return;
        }

        if (Input.GetButtonDown("WeaponSwitch"))
        {
            switcher.SwitchWeapon();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            weapons[switcher.ActiveWeapon].AttackEvent.Invoke();
        }
    }


}
