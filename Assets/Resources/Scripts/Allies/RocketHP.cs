using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHP : AllyHealthHandler
{
    public override void DealDamage(float damage)
    {
        if (dead) return;
        hp -= damage;
        if (hp <= 0f)
        {
            // TODO: LOSE();
            return;
        }
    }
}
