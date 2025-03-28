using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : ProjectileWeaponBase, IReloadable
{
    
    private bool reloadingShotgun = false;
    private bool shooting = false;
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
        shotsLeft = plAmmo.shotgunAmmo;
    }

    public void ShootWep()
    {
        if (shotCooldown && shotsLeft > 0)
        {
            shooting = true;
            reloadingShotgun = false;
            shotCooldown = false;
            StartCoroutine(ShootShotgun());
        }
    }

    private IEnumerator ShootShotgun()
    {
        Debug.Log("test shot");
        ShootShotgunWep();
        plAmmo.shotgunAmmo -= 1;
        plAmmo.UpdateShotgun();
        yield return new WaitForSeconds(.3f);
        shooting = false;
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
            if(hit.collider != null && hit.collider.gameObject.GetComponent<TargetDummy>() != null)
            {
                targetDummy = hit.collider.gameObject.GetComponent<TargetDummy>();
                targetDummy.TakeDamage(damage);
            }
        }
    }
    public void Reload()
    {
        reloadingShotgun = true;
        if(magazineSize > shotsLeft&& plAmmo.sAmmo >= 1 && reloadingShotgun && !shooting)
        {
            reloadingShotgun = false;
            Invoke("Reloading",reloadTime);
        }
        
    }
    private void Reloading()
    {
        if (magazineSize > shotsLeft)
        {
            plAmmo.GetSAmmo(-1);
            plAmmo.shotgunAmmo += 1;
            plAmmo.UpdateShotgun();
            reloadingShotgun = true;
            Reload();
        }
    }

}
