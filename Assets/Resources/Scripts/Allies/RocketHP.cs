using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHP : AllyHealthHandler
{
    [SerializeField] private Material material;
    [SerializeField] private Color baseColor;
    [SerializeField] private float startIntensity;
    [SerializeField] private AudioClip hitSound;
    private AudioSource audioSource;
    private float intensity;
    private float intentisyDecreaser;

    protected override void Start()
    {
        audioSource = GetComponent<AudioSource>();
        intensity = startIntensity;
        intentisyDecreaser = startIntensity / hp;
        material.SetColor("_color", baseColor * intensity);
    }

    public override void DealDamage(float damage)
    {
        if (dead) return;
        hp -= damage;
        intensity -= intentisyDecreaser;
        material.SetColor("_color", baseColor * intensity);
        if (hp <= 0f)
        {
            sceneChanger.Lose();
            return;
        }
        audioSource.PlayOneShot(hitSound);
    }
}
