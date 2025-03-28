using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class projectileBase : MonoBehaviour
{
    public int damage;
    public string targetTag;

    void OnCollisionEnter(Collision other)
    {
        if ( other.gameObject.tag == targetTag)
        {
           DealDamage(damage); 
        }
        

        Destroy(gameObject);

    }
    public abstract void DealDamage(int damage);
    
   

}
