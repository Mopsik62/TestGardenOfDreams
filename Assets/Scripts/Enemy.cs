using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter
{
    private void Awake()
    {
        HealthBar.SetMaxHealth(MaxHp);
    }
}
