using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class MachineGun : RaycastWeaponBase, IShotSpread //IAutomatic
{
    private bool firing = false; //{ get; set;}
    float IShotSpread.spread { get; set; } = 3f;
    public bool shotCooldown = true;
    public int damage;
    public TargetDummy targetDummy;
    private bool reloadingMG = false;
    public WeaponController wc;
    public PlayerAmmo plAmmo;
    
    void OnEnable()
    {
        WeaponController.Shoot += StartFiring;
        WeaponController.StopShoot += StopFiring;
        WeaponController.Reload += Reload;
        WeaponController.Delete += Despawn;
    }
    void OnDisable()
    { 
        WeaponController.Shoot -= StartFiring;
        WeaponController.StopShoot -= StopFiring;
        WeaponController.Reload += Reload;
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
            StartCoroutine(ShootMG());
        }
    }

    private IEnumerator ShootMG()
    {
        Debug.Log("test shot");
        ShootMachineGun();
        plAmmo.mgAmmo -= 1;
        plAmmo.UpdateMachinegun();
        yield return new WaitForSeconds(.1f);
        shotCooldown = true;
        yield return null;
    }

    private void ShootMachineGun()
    {
        
        Ray Shot = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(Shot, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit " + hit.collider.name);
            if(hit.collider != null)
            {
                targetDummy = hit.collider.gameObject.GetComponent<TargetDummy>();
                targetDummy.TakeDamage(damage);
            }
        }
    }

    private void Reload()
    {
        reloadingMG = true;
        StartCoroutine(Reloading(reloadTime));
    }
    private IEnumerator Reloading(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
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
