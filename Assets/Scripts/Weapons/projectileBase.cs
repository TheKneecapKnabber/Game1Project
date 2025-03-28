using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class projectileBase : MonoBehaviour
{
    public int damage;
    public Rigidbody rb;
    //public string targetTag;
    private void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        
        if ( other.gameObject.tag == "Enemy")
        {
           DealDamage(damage, other); 
        }
        
        
        //DealDamage(damage, other);
        if( other.gameObject.tag != "Projectile")
        {
            Destroy(gameObject, 0.05f);
        }
        

    }
    public void DealDamage(int damage, Collision a)
    {
        if (a.gameObject.tag == "Enemy")
        {
            a.gameObject.GetComponent<TargetDummy>().TakeDamage(damage);
        }
        else if (a.gameObject.tag == "Player")
        {
            a.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }


    }
    
   

}
