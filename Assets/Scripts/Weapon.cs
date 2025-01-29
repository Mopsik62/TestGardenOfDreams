using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int MaxAmmo;
    public int CurAmmo;
    public float bulletSpeed = 10f; 

    public AmmoHandler AmmoHandler;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Ammo ammo;
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

            Ammo newAmmo = Instantiate(ammo, muzzle.position, transform.rotation);

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
