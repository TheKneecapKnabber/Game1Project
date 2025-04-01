using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class MachineGun : RaycastWeaponBase, IReloadable, IShotSpread //IAutomatic
{
    private bool firing = false; //{ get; set;}
    float IShotSpread.spread { get; set; } = 3f;
    public bool shotCooldown = true;
    //public int damage;
    public EnemyBase Enemy;
    private bool reloadingMG = false;
    public WeaponController wc;
    public PlayerAmmo plAmmo;
    
    void OnEnable()
    {
        WeaponController.Shoot += StartFiring;
        WeaponController.StopShoot += StopFiring;
        //WeaponController.Reload += Reload;
        WeaponController.Delete += Despawn;
    }
    void OnDisable()
    { 
        WeaponController.Shoot -= StartFiring;
        WeaponController.StopShoot -= StopFiring;
        //WeaponController.Reload += Reload;
        WeaponController.Delete += Despawn;
    }

    void Awake()
    {
        shotsLeft = magazineSize;
        if (wc == null)
        {
            wc = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>();
        }
        if (plAmmo == null)
        {
            plAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAmmo>();
        }
    }

    public void StartFiring()
    {
        firing = true;
    }

    public void StopFiring()
    {
        firing = false;
    }

    void Update()
    {
        shotsLeft = plAmmo.mgAmmo;
        if (firing && shotCooldown && shotsLeft > 0 && !reloadingMG)
        {
            shotCooldown = false;
            //Coroutine co = StartCoroutine(ShootMG());
            ShootMachineGun();
            plAmmo.mgAmmo -= 1;
            plAmmo.UpdateMachinegun();
            Invoke("ShootMG",0.1f);
        }
    }

    private void ShootMG()
    {
        Debug.Log("test shot");
        //yield return new WaitForSeconds(.1f);

        shotCooldown = true;
        //yield return null;
    }

    private void ShootMachineGun()
    {
        
        Ray Shot = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(Shot, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit " + hit.collider.name);
            if(hit.collider != null && hit.collider.gameObject.GetComponent<EnemyBase>() != null)//targetdummy will be changed to enemybase
            {
                Enemy = hit.collider.gameObject.GetComponent<EnemyBase>();//targetdummy will be changed to enemybase
                Enemy.TakeDamage(damage);
            }
        }
    }

    public void Reload()
    {
        reloadingMG = true;
        Invoke("Reloading", reloadTime);
    }
    private void Reloading()
    {
        //yield return new WaitForSeconds(reloadTime);
        if(magazineSize > shotsLeft && plAmmo.nAmmo >= (magazineSize - shotsLeft))
        {
            plAmmo.GetNAmmo(shotsLeft - magazineSize);
            plAmmo.mgAmmo = magazineSize;
            plAmmo.UpdateMachinegun();
        }
        else if(magazineSize > shotsLeft && plAmmo.nAmmo < (magazineSize - shotsLeft))
        {
            int newAmmo = plAmmo.nAmmo;
            plAmmo.GetNAmmo(-plAmmo.nAmmo);
            plAmmo.mgAmmo += newAmmo;
            plAmmo.UpdateMachinegun();
        }
        reloadingMG = false;
    }

}
