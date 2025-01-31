using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Fighter
{
    [SerializeField] private Weapon weapon;

    public override void Initialize()
    {
        base.Initialize();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("Shoot");
            weapon.Shot();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Item"))
        {
            ItemController itemConroller = coll.gameObject.GetComponent<ItemController>();
            itemConroller.Pickup();
        }
    }
}
