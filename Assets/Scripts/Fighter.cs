using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int MaxHp;
    public int CurHp;

    public HealthBar HealthBar;
    public virtual void Initialize()
    {
        CurHp = MaxHp;
        HealthBar.SetMaxHealth(MaxHp);
    }

    protected virtual void Death()
    {
        Debug.Log("Death of " + name);
    }
}
