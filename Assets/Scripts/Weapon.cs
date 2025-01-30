using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int MaxAmmo;
    public int CurAmmo;
    public float bulletSpeed = 10f;
    public int weaponDamage;
    private bool canShoot = false;

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
        if (!canShoot)
           return;
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            canShoot = true;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Vector2 enemyPosition = col.transform.position;
            Vector2 myPosition = transform.position;

            Vector2 direction = enemyPosition - myPosition;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 

            if (angle > 90 || angle < -90)
            {
                transform.localScale = new Vector3(1, -1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            canShoot = false;
            transform.rotation = Quaternion.Euler(0, 0, 0); 
            transform.localScale = new Vector3(1, 1, 1); 
        }
    }


}
