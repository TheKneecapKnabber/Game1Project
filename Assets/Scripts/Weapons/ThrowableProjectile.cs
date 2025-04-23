using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableProjectile : projectileBase
{
    [SerializeField] private GameObject staticObject;//object that gets spawned to stick to the collided object
    protected override void OnCollisionEnter(Collision other)
    {
        if (other.collider != null && other.collider.gameObject.GetComponent<IDamageable>() != null)
        {
            DealDamage(other);
        }
        
            Instantiate(staticObject, gameObject.transform.position, gameObject.transform.rotation, other.transform.root);
            Destroy(gameObject);
        
        
        //Debug.Log(other.gameObject.name);
        //Instantiate(staticObject,gameObject.transform.position, gameObject.transform.rotation, other.transform.root);

        /*
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            //set fixed joint
        }
        else
        {
            //transform.SetParent(other.transform, true);
            
            
        }
        */
        //transform.SetParent(other.transform.root,  true);
        //rb.useGravity = false;
    }
    
}
