using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RaycastWeaponBase, IReloadable
{
    private bool reloadingPistol = false;
    public int damage;
    public bool shotCooldown = true;
    public TargetDummy targetDummy;
    public WeaponController wc;
    public PlayerAmmo plAmmo;

    void OnEnable()
    {
        WeaponController.Shoot += ShootWep;
        WeaponController.Reload += Reload;
        WeaponController.Delete += Despawn;
    }
    void OnDisable()
    { 
        WeaponController.Shoot -= ShootWep;
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

    void Update()
    {
        shotsLeft = plAmmo.pistolAmmo;
    }

    public void ShootWep()
    {
        if (shotCooldown && shotsLeft > 0 && !reloadingPistol)
        {
            shotCooldown = false;
            ShootPistolWep();
            plAmmo.pistolAmmo -= 1;
            plAmmo.UpdatePistol();
            Invoke("ShootPistol",0.3f);
        }
    }

    private void ShootPistol()
    {
        Debug.Log("test shot");

        //yield return new WaitForSeconds(.3f);
        shotCooldown = true;
        //yield return null;
    }

    private void ShootPistolWep()
    {
        Ray Shot = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(Shot, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit " + hit.collider.name);
            if(hit.collider != null && hit.collider.gameObject.GetComponent<TargetDummy>() != null)
            {
                targetDummy = hit.collider.gameObject.GetComponent<TargetDummy>();
                targetDummy.TakeDamage(damage);
            }
        }
    }

    public void Reload()
    {
        reloadingPistol = true;
        Invoke("Reloading",reloadTime);
    }
    private void Reloading()
    {
        //yield return new WaitForSeconds(reloadTime);
        if(magazineSize > shotsLeft && plAmmo.nAmmo >= (magazineSize - shotsLeft))
        {
            plAmmo.GetNAmmo(shotsLeft - magazineSize);
            plAmmo.pistolAmmo = magazineSize;
            plAmmo.UpdatePistol();
        }
        else if(magazineSize > shotsLeft && plAmmo.nAmmo < (magazineSize - shotsLeft))
        {
            int newAmmo = plAmmo.nAmmo;
            plAmmo.GetNAmmo(-plAmmo.nAmmo);
            plAmmo.pistolAmmo += newAmmo;
            plAmmo.UpdatePistol();
        }
        reloadingPistol = false;
    }





}
