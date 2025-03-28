using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RaycastWeaponBase 
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
            StartCoroutine(ShootPistol());
        }
    }

    private IEnumerator ShootPistol()
    {
        Debug.Log("test shot");
        ShootPistolWep();
        plAmmo.pistolAmmo -= 1;
        plAmmo.UpdatePistol();
        yield return new WaitForSeconds(.3f);
        shotCooldown = true;
        yield return null;
    }

    private void ShootPistolWep()
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
        reloadingPistol = true;
        StartCoroutine(Reloading(reloadTime));
    }
    private IEnumerator Reloading(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
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
