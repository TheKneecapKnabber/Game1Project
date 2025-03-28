using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class MachineGun : RaycastWeaponBase, IAutomatic, IShotSpread
{
    public bool firing { get; set;}
    float IShotSpread.spread { get; set; } = 3f;
   
    void OnEnable()
    {
        WeaponController.Shoot += StartFiring;
        WeaponController.StopShoot += StopFiring;
        WeaponController.Reload += CanReload;
        WeaponController.Delete += Despawn;
    }
    void OnDisable()
    {
        WeaponController.Shoot -= StartFiring;
        WeaponController.StopShoot -= StopFiring;
        WeaponController.Reload += CanReload;
        WeaponController.Delete += Despawn;
    }

    public override void Fire(Transform shootpoint)
    {
        //base.Fire(shootpoint);
        StartFiring();
    }
    public void StartFiring()
    {
        firing = true;
    }

    public void StopFiring()
    {
        firing = false;
    }
}
