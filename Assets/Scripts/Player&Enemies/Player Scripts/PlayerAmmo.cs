using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public static event Action<int> OnNAmmoChange;
    public static event Action<int> OnSAmmoChange;
    public static event Action<int> OnTAmmoChange;
    public static event Action<int> OnSGChange;
    public static event Action<int> OnPistolChange;
    public static event Action<int> OnMGChange;
    public static event Action<int> OnTChange;

    [SerializeField] private int maxNAmmo = 120; //normal bullets
    [SerializeField] private int maxSAmmo = 60; //shotgun bullets
    [SerializeField] private int maxTAmmo = 20; //throwable weapon

    //current ammo of that type
    public int nAmmo ;
    public int sAmmo ;
    public int tAmmo ;

    //current weapon magazines (throwAmmo might not be nessicary)
    public int shotgunAmmo = 0, mgAmmo = 0, pistolAmmo = 0, throwAmmo = 0;
    public WeaponController wc;


    // Start is called before the first frame update
    void Start()
    {
        OnNAmmoChange?.Invoke(nAmmo);
        OnSAmmoChange?.Invoke(sAmmo);
        OnTAmmoChange?.Invoke(tAmmo);
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
    public void GetTAmmo(int amt)
    {
        tAmmo += amt;
        if (tAmmo > maxTAmmo)
        {
            tAmmo = maxTAmmo;
            OnTAmmoChange?.Invoke(tAmmo);
        }
        else if (tAmmo == 0)
        {
            wc.hasThrowable = false;//disables the weapon from getting switched to if there is no ammo
            OnTAmmoChange?.Invoke(tAmmo);
        }
        else
        {
            OnTAmmoChange?.Invoke(tAmmo);
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
    public void UpdateThrowable()
    {
        OnTChange?.Invoke(throwAmmo);
    }

}
