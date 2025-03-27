using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public static event Action<int> OnNAmmoChange;
    public static event Action<int> OnSAmmoChange;

    public int maxNAmmo = 120; //normal bullets
    public int maxSAmmo = 60; //shotgun bullets

    [SerializeField]public int nAmmo {get; private set;}
    [SerializeField] public int sAmmo { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        OnNAmmoChange?.Invoke(nAmmo);
        OnSAmmoChange?.Invoke(sAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
