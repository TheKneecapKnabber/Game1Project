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
    [SerializeField] private float projectileSpeed;//how fast the bullet flys out

    //spaces out the shots so it doesn't just shoot a burst out
    [SerializeField] private float timeBetweenShots;
    private bool shot = false;//prevents corutine from getting called multiple times per sec

    //sets up accuracy of the guard
    [SerializeField] private float spread = 0f;// don't set it very high
    private float spreadX, spreadY, spreadZ;

    //uses ai
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

        
       //set up inaccuracy from 0 to storm troopers (the inaccuracy is a very fast ramp up)
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
