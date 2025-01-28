using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] Player _player;

    private void Awake()
    {
        _player.Initialize();
    }
}
