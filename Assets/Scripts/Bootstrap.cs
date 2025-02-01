using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Weapon _weapon;
    [SerializeField] InventoryManager _inventoryManager;
    [SerializeField] GameManager _gameManager;

    private void Awake()
    {
        _player.Initialize();
        _weapon.Initialize();
        _inventoryManager.Initialize();
        _gameManager.Initialize();
    }
}
