using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : IWeaponBehavior
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;

    public void Fire(Transform shootPoint)
    {
        GameObject projectile = GameObject.Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = shootPoint.position * projectileSpeed;
        Debug.Log("Weapon was shot");
    }
}
