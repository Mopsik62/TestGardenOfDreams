using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int MaxHp;
    public int CurHp;

    public float immuneTime = 1f;
    protected float lastImmune;

    protected virtual void Awake()
    {
        lastImmune = Time.time;
    }

    public HealthBar HealthBar;
    public virtual void Initialize()
    {
        CurHp = MaxHp;
        HealthBar.SetMaxHealth(MaxHp);
        HealthBar.SetHealth(MaxHp);
    }

    public void ReciveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            CurHp -= dmg.damage;
            HealthBar.SetHealth(CurHp);
            if (CurHp <= 0)
            {
                Death();
            }
        }

    }

    protected virtual void Death()
    {
        Debug.Log("Death of " + name);
        Destroy(gameObject);
    }
}
