using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    private WeaponSwitcher switcher;
    private float cooldownTimer;
    private Animator animator;

    public List<Weapon> Weapons => weapons;

    private void Start()
    {
        switcher = GetComponent<WeaponSwitcher>();
        cooldownTimer = 0f;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (!Input.anyKeyDown)
        {
            return;
        }

        if (Input.GetButtonDown("WeaponSwitch"))
        {
            cooldownTimer = 0f;
            switcher.SwitchWeapon();
        }

        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0)
        {
            animator.SetTrigger(weapons[switcher.ActiveWeapon].AnimationTrigger);
            cooldownTimer = weapons[switcher.ActiveWeapon].Cooldown;
        }
    }


}
