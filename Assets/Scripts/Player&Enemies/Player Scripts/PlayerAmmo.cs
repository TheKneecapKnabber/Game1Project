using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public static event Action<int> OnNAmmoChange;
    public static event Action<int> OnSAmmoChange;
    public static event Action<int> OnSGChange;
    public static event Action<int> OnPistolChange;
    public static event Action<int> OnMGChange;

    public int maxNAmmo = 120; //normal bullets
    public int maxSAmmo = 60; //shotgun bullets

    [SerializeField]public int nAmmo ;
    [SerializeField] public int sAmmo ;

    public int shotgunAmmo = 0, mgAmmo = 0, pistolAmmo = 0;
    public WeaponController wc;


    // Start is called before the first frame update
    void Start()
    {
        OnNAmmoChange?.Invoke(nAmmo);
        OnSAmmoChange?.Invoke(sAmmo);
        OnMGChange?.Invoke(mgAmmo);
        OnPistolChange?.Invoke(pistolAmmo);
        OnSGChange?.Invoke(shotgunAmmo);
    }

    public void GetNAmmo(int amt)
    {
        nAmmo += amt;
        if (nAmmo > maxNAmmo)
        {
            nAmmo = maxNAmmo;
            OnNAmmoChange?.Invoke(nAmmo);
        }
        else
        {
            OnNAmmoChange?.Invoke(nAmmo);
        }
        
    }
    public void GetSAmmo(int amt)
    {
        sAmmo += amt;
        if (sAmmo > maxSAmmo)
        {
            sAmmo = maxSAmmo;
            OnSAmmoChange?.Invoke(sAmmo);
        }
        else
        {
            OnSAmmoChange?.Invoke(sAmmo);
        }

    }

    public void UpdateShotgun()
    {
        OnSGChange?.Invoke(shotgunAmmo);
    }
    public void UpdatePistol()
    {
        OnPistolChange?.Invoke(pistolAmmo);
    }
    public void UpdateMachinegun()
    {
        OnMGChange?.Invoke(mgAmmo);
    }

}
