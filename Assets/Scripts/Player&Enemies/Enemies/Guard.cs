using AICore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;





public class Guard : EnemyBase
{
       
    //needed for attack with ranged weapon
    [SerializeField] private Transform shootPoint;
    public GameObject projectilePrefab;
    public float projectileSpeed;
    [SerializeField] private float timeBetweenShots;
    private bool shot = false;
    [SerializeField] private float spread = 0f;
    private float spreadX, spreadY, spreadZ;
    [SerializeField] private EnemyAI ai;

    public override void Attack() 
    {
        
       
        if (!shot)
        {
            Debug.Log("Attack");
            //set shot equal to true
            shot = true;
            StartCoroutine(Shoot());
        }
        //shoot projectile from gun to player
        
        
       
    }
    IEnumerator Shoot()
    {
        

        //shoot projectile
        Vector3 direction = ai.GetVisualTargetPosition - shootPoint.position;

        
       //set up in inaccuracy from 0 to storm troopers 
        spreadX = Random.Range(-spread, spread);
        spreadY = Random.Range(-spread, spread);
        spreadZ = Random.Range(-spread, spread);
        Vector3 dirSpread = direction + new Vector3(spreadX, spreadY, spreadZ);

        GameObject curBullet = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        curBullet.transform.forward = dirSpread.normalized;


        curBullet.GetComponent<Rigidbody>().velocity = (dirSpread.normalized * projectileSpeed);
        curBullet.GetComponent<projectileBase>().damage = damage; //set the projectile damage
        yield return new WaitForSeconds(timeBetweenShots);
        //reset shot bool
        shot = false;
        yield return null;
    }
}
