using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : ProjectileWeaponBase, IReloadable
{
    
    private bool reloadingShotgun = false;
    private bool shooting = false;
    //public int damage;
    public bool shotCooldown = true;
    public EnemyBase EnemyBase;
    public WeaponController wc;
    public PlayerAmmo plAmmo;
    int bullets = 10;//how many get shot at once
    public float spread = 1f;// sets the range on the spread
    private float spreadX, spreadY, spreadZ;// random values that get set later based on the spread

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
        //Debug.Log("test shot");
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
       
        Vector3 target;
       
        target = Shot.GetPoint(50);//set target to what the player is looking at
        //had to use get point because if object is too close the bullets would go out at a weird angle
        //

        Vector3 direction = target - shootPoint.position;
        //Debug.DrawRay(shootPoint.position, direction);

        //spawn and shoot bullets
        for(int i = 0; i < bullets; i++)
        {
            spreadX = Random.Range(-spread, spread);
            spreadY = Random.Range(-spread, spread);
            spreadZ = Random.Range(-spread, spread);
            Vector3 dirSpread = direction + new Vector3(spreadX, spreadY, spreadZ);

            GameObject curBullet = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            curBullet.transform.forward = dirSpread.normalized;

            
            curBullet.GetComponent<Rigidbody>().velocity = (dirSpread.normalized * projectileSpeed);
            curBullet.GetComponent<projectileBase>().damage = damage; //set the projectile damage

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
