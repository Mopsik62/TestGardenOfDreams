using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int bulletDamage;
    private void Start()
    {
        Destroy(gameObject, 2.0f);
    }
    public void SetDamage(Damage damage)
    {
        bulletDamage = damage.damage;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Ssss");
            Damage dmg = new()
            {
                damage = bulletDamage,
            };
            col.gameObject.SendMessage("ReciveDamage", dmg);
        }
    }


}
