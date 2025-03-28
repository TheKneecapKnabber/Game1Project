using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : ProjectileWeaponBase
{
    
    private bool reloadingShotgun = false;
    public int damage;
    public bool shotCooldown = true;
    public TargetDummy targetDummy;
    public WeaponController wc;
    public PlayerAmmo plAmmo;
    private Coroutine co = null;

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
        shotsLeft = plAmmo.shotgunAmmo;
    }

    public void ShootWep()
    {
        if (shotCooldown && shotsLeft > 0 && !reloadingShotgun)
        {
            shotCooldown = false;
            StartCoroutine(ShootShotgun());
            if(reloadingShotgun && co != null)
            {
                StopCoroutine(co);
            }
        }
    }

    private IEnumerator ShootShotgun()
    {
        Debug.Log("test shot");
        ShootShotgunWep();
        plAmmo.shotgunAmmo -= 1;
        plAmmo.UpdateShotgun();
        yield return new WaitForSeconds(.3f);
        shotCooldown = true;
        yield return null;
    }

    private void ShootShotgunWep()
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
        reloadingShotgun = true;
        co = StartCoroutine(Reloading(reloadTime));
    }
    private IEnumerator Reloading(float reloadTime)
    {
        while(magazineSize > shotsLeft&& plAmmo.sAmmo >= 1)
        {
            yield return new WaitForSeconds(reloadTime);

            plAmmo.GetSAmmo(-1);
            plAmmo.shotgunAmmo += 1;
            plAmmo.UpdateShotgun();
            yield return null;
        }
        /*else if(magazineSize > shotsLeft && plAmmo.sAmmo < (magazineSize - shotsLeft))
        {
            int newAmmo = plAmmo.nAmmo;
            plAmmo.GetSAmmo(-plAmmo.nAmmo);
            plAmmo.shotgunAmmo += newAmmo;
            plAmmo.UpdateShotgun();
        }*/
        reloadingShotgun = false;
    }

}
