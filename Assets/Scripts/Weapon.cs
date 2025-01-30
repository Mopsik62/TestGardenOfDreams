using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int MaxAmmo;
    public int CurAmmo;
    public float bulletSpeed = 10f;
    public int weaponDamage;

    public AmmoHandler AmmoHandler;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Ammo ammoType;
    public void Initialize()
    {
        CurAmmo = MaxAmmo;
        AmmoHandler.SetMaxAmmo(MaxAmmo);
        AmmoHandler.SetCurAmmo(CurAmmo);
    }
    public void Shot()
    {
        if (CurAmmo > 0) 
        {
            CurAmmo--;
            AmmoHandler.SetCurAmmo(CurAmmo);
            Damage dmg = new()
            {
                damage = weaponDamage,
            };
            Ammo newAmmo = Instantiate(ammoType, muzzle.position, transform.rotation);
            newAmmo.SetDamage(dmg);
            Rigidbody2D rb = newAmmo.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * bulletSpeed; 
            }
        }
        else
        {
            Debug.Log("No ammo left");
        }
    }
}
