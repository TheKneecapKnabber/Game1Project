using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class projectileBase : MonoBehaviour
{
    public int damage = 1;
    public Rigidbody rb;
    [SerializeField]protected float timeTillDestroy = 15;
    //public string targetTag;
    private void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }

    void OnCollisionEnter(Collision other)
    {
        
        if ( other.gameObject.tag == "Enemy"|| other.gameObject.tag == "Player")
        {
           DealDamage(other); 
        }
        Destroy(gameObject);
        
        //DealDamage(damage, other);
        
        

    }
    public void DealDamage(Collision a)
    {
        //Debug.Log("in dealing damage");
        if (a.gameObject.tag == "Enemy")
        {
            //Debug.Log("hit enemy");
            a.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
        }
        else if (a.gameObject.tag == "Player")
        {
            a.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        Destroy(this.gameObject, 0.5f);

    }
    
   

}
