﻿using UnityEngine;

public class WeaponEvents : MonoBehaviour
{
    [SerializeField] private float meleeAttackRadius;
    [SerializeField] private float basicDamage;
    [SerializeField] private float comboMultiplier;
    [SerializeField] private GameObject totemPrefab;
    private GameObjectsPool projectiles;
    private Crosshair crosshair;
    private ComboHandler combo;

    private void Start()
    {
        combo = GetComponent<ComboHandler>();
        crosshair = GetComponent<Crosshair>();
        projectiles = GetComponent<GameObjectsPool>();
    }

    public void MeleeAxeHit()
    {
        var colliders = Physics2D.OverlapCircleAll(crosshair.AttackPoint, meleeAttackRadius);
        foreach (var collider in colliders)
        {
            if (!collider.CompareTag("Player"))
            {
                EnemyHealth enemy;
                if(collider.TryGetComponent<EnemyHealth>(out enemy))
                {
                    enemy.DealDamage(basicDamage * Mathf.Pow(comboMultiplier, combo.Combo));
                    combo.IncreaseCombo();
                }
            }
        }
    }

    public void ShootProjectile()
    {
        GameObject projectile = projectiles.GetObject();

        projectile.transform.position = crosshair.AttackPoint;
        projectile.transform.rotation = crosshair.AttackDirection;

        var wave = projectile.GetComponent<ShootWaveController>();
        wave.SetDamage(Mathf.Pow(comboMultiplier, combo.Combo));

        if (projectile.activeSelf)
        {
            projectile.SetActive(false);
        }
        projectile.SetActive(true);
    }

    public void SpawnTotem()
    {
        Vector3 localTotemPosition = Random.Range(-1f, 1f) * transform.up + Random.Range(-1f, 1f) * transform.right;
        GameObject totem = Instantiate(totemPrefab, localTotemPosition + transform.position, Quaternion.Euler(0,0,0));
        totem.GetComponent<BuffTotem>().PlayerComboHandler = combo;
    }
}
