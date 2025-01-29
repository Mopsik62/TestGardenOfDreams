using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Weapon _weapon;

    private void Awake()
    {
        _player.Initialize();
        _weapon.Initialize();
    }
}
