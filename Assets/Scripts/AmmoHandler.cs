
using UnityEngine;
using TMPro;

public class AmmoHandler : MonoBehaviour
{
    public TMP_Text MaxAmmo;
    public TMP_Text CurAmmo;

    public void SetMaxAmmo(int ammo)
    {
        MaxAmmo.text = ammo.ToString();
    }

    public void SetCurAmmo(int ammo)
    {
        CurAmmo.text = ammo.ToString();
    }
}
