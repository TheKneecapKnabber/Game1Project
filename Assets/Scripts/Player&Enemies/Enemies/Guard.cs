using AICore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;





public class Guard : EnemyBase
{
       
    //needed for attack with ranged weapon
    [SerializeField] private Transform shootPoint;
    public GameObject projectilePrefab;
    public float projectileSpeed;
    [SerializeField] private float timeBetweenShots;
    private bool shot = false;

    public override void Attack() 
    {
        
       
        if (!shot)
        {
            StartCoroutine(Shoot());
        }
        //shoot projectile from gun to player
        Debug.Log("Attack");
        
       
    }
    IEnumerator Shoot()
    {
        //set shot equal to true
        shot = true;
        
        //shoot projectile

        
        //wait timeBetweenShots
        yield return new WaitForSeconds(timeBetweenShots);

        //reset shot bool
        shot = false;
        yield return null;
    }
}
