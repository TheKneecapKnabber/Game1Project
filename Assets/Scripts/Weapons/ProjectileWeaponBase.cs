using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileWeaponBase : WeaponBase
{
    public GameObject projectilePrefab;
    public float projectileSpeed;

    public override void Fire(Transform shootPoint)
    {
        GameObject projectile = GameObject.Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = shootPoint.position * projectileSpeed;


    }
}
