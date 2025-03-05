using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase
{


    public Transform shootpoint;
    public IWeaponBehavior weaponBehavior;

    public void SetWeaponBehavior(IWeaponBehavior newBehavior)
    {
        weaponBehavior = newBehavior;

    }

    public void Use()
    {
        if (weaponBehavior != null)
        {
            weaponBehavior.Fire(shootpoint);
        }
        else
        {
            Debug.Log("no behavior set");
        }
    }
}
