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
            Debug.Log("Shoot");
            weapon.Shot();
        }
    }
}
