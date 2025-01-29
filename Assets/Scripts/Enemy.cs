using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter
{
    [SerializeField] private GameObject Loot;
    private void Awake()
    {
        HealthBar.SetMaxHealth(MaxHp);
    }

    protected override void Death()
    {
        base.Death();
        Instantiate(Loot);
    }
}
