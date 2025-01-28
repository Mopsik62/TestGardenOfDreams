using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int MaxHp;
    public int CurHp;

    public HealthBar HealthBar;

    private void Awake()
    {
        CurHp = MaxHp;
        HealthBar.SetMaxHealth(MaxHp);
    }
    protected void Death()
    {
        Debug.Log("Death of " + name);
    }
}
