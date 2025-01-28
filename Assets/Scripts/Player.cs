using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Fighter
{
    public int MaxAmmo;
    public int CurAmmo;

    public AmmoHandler Ammo;

    public override void Initialize()
    {
        base.Initialize();
        CurAmmo = MaxAmmo;
        Ammo.SetMaxAmmo(CurAmmo);
        Ammo.SetCurAmmo(CurAmmo);
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Shoot");
            CurAmmo--;
            Ammo.SetCurAmmo(CurAmmo);
        }
    }
}
