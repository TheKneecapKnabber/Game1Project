using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : ProjectileWeaponBase, IReloadable
{
    [SerializeField] private WeaponController wc;
    [SerializeField] private PlayerAmmo pa;

    [SerializeField] private GameObject meshHolder;//child object that holds the mesh objects
    public bool canThrow = true;
    [SerializeField] private float throwCooldown = 1f;// how many seconds is the cooldown

    private void Start()
    {
        if (wc == null)
        {
            wc = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>();
        }
        if (pa == null)
        {
            pa = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAmmo>();
        }
    }

    void OnEnable()
    {
        WeaponController.Shoot += ShootWep;

        
    }
    void OnDisable()
    {
        WeaponController.Shoot -= ShootWep;

       
    }

    //throw current weapon
    void ShootWep()
    {
        if (canThrow)
        {
            canThrow = false;

            StartCoroutine(ThrowWeapon(throwCooldown));
        }
        

    }
    
    private IEnumerator ThrowWeapon(float throwCooldown)
    {
        meshHolder.SetActive(false);
        Toss();

        yield return new WaitForSeconds(throwCooldown);
        canThrow = true;
        meshHolder.SetActive(true);
        yield return null;

        
    }
    private void Toss()
    {
        pa.tAmmo -= 1;
        pa.UpdateThrowable();
        RaycastHit hit;
        Ray Shot = cam.ScreenPointToRay(Input.mousePosition);

        Vector3 target;

        if (Physics.Raycast(Shot, out hit))
        {
            target = hit.point;
        }
        else
        {
            target = Shot.GetPoint(30);
        }
        Vector3 direction = target - shootPoint.position;
        GameObject curBullet = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        curBullet.transform.forward = direction.normalized;

        curBullet.GetComponent<Rigidbody>().velocity = (direction.normalized * projectileSpeed);
        curBullet.GetComponent<projectileBase>().damage = damage; //set the projectile damage

    }
    public void Reload()
    {
        //nothing
    }

    //this will need a new pickup script for the ammo since ammo and weapon are the same
}
