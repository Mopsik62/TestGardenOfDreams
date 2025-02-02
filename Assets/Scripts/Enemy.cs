using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter
{
    [SerializeField] private GameObject[] Loot;
    public int contactDamage;
    protected override void Awake()
    {
        base.Awake();
        HealthBar.SetMaxHealth(MaxHp);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Damage dmg = new()
            {
                damage = contactDamage,
            };
            coll.gameObject.SendMessage("ReciveDamage", dmg);
        }
    }
    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Damage dmg = new()
            {
                damage = contactDamage,
            };
            coll.gameObject.SendMessage("ReciveDamage", dmg);
        }
    }

    protected override void Death()
    {
        base.Death();
        Instantiate(Loot[Random.Range(0, Loot.Length)], transform.position, Quaternion.identity);
    }
}
