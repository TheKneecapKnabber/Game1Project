using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : ProjectileWeaponBase, IReloadable
{
    
    private bool reloadingShotgun = false;
    private bool shooting = false;
    //public int damage;
    public bool shotCooldown = true;
    public TargetDummy targetDummy;
    public WeaponController wc;
    public PlayerAmmo plAmmo;
    //int bullets = 9;
    public float spread = 1f;
    //private float spreadX, spreadY;

    void OnEnable()
    {
        WeaponController.Shoot += ShootWep;
        
        WeaponController.Delete += Despawn;
    }
    void OnDisable()
    { 
        WeaponController.Shoot -= ShootWep;
        
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
        //Ray Shot = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0.5f));
        RaycastHit hit;

        
        if (Physics.Raycast(Shot, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit " + hit.collider.name);
            if(hit.collider != null && hit.collider.gameObject.GetComponent<TargetDummy>() != null)//targetdummy will be changed to enemybase
            {
                targetDummy = hit.collider.gameObject.GetComponent<TargetDummy>();//targetdummy will be changed to enemybase
                targetDummy.TakeDamage(damage);
            }
        }
        
        /*
        //so the bullets come from the gun to where the player is looking
        Vector3 target;
        if (Physics.Raycast(Shot, out hit)) 
            target = hit.point;
        else 
            target = Shot.GetPoint(100);

        Vector3 direction = target - shootPoint.position;
        Debug.DrawRay(shootPoint.position, direction);

        //spawn and shoot bullets
        for(int i = 0; i < bullets; i++)
        {
            spreadX = Random.Range(-spread, spread);
            spreadY = Random.Range(-spread, spread);
            Vector3 dirSpread = direction + new Vector3(spreadX, spreadY);

            GameObject curBullet = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            curBullet.transform.forward = dirSpread.normalized;

            
            curBullet.GetComponent<Rigidbody>().velocity = (dirSpread.normalized * projectileSpeed);
            curBullet.GetComponent<projectileBase>().damage = damage; //set the projectile damage

        }
        */
        
        
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
