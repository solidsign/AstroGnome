using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    private WeaponSwitcher switcher;
    private float cooldownTimer;
    private Animator animator;
    private AudioHandler audioHandler;

    public List<Weapon> Weapons => weapons;

    private void Start()
    {
        switcher = GetComponent<WeaponSwitcher>();
        cooldownTimer = 0f;
        animator = GetComponent<Animator>();
        audioHandler = GetComponent<AudioHandler>();
        foreach (var weapon in weapons)
        {
            audioHandler.AddSound(weapon.SoundName);
        }
        audioHandler.AddSound("WeaponSwitch");
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
            //audioHandler.PlaySound("WeaponSwitch");
            switcher.SwitchWeapon();
        }

        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0f)
        {
            int activeWeapon = switcher.ActiveWeapon;
            audioHandler.PlaySound(weapons[activeWeapon].SoundName, weapons[activeWeapon].SoundVolume);
            animator.SetTrigger(weapons[activeWeapon].AnimationTrigger);
            cooldownTimer = weapons[activeWeapon].Cooldown;
        }
    }


}
