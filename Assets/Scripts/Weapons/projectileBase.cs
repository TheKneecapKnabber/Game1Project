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
    [SerializeField]protected float timeTillDestroy = 5;
    //public string targetTag;
    private void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        
        if (other.collider != null && other.collider.gameObject.GetComponent<IDamageable>() != null)
        {
           DealDamage(other); 
        }
        Destroy(gameObject);
        
        //DealDamage(damage, other);
        
        

    }
    public void DealDamage(Collision a)
    {
        //Debug.Log("in dealing damage");

        a.gameObject.GetComponent<IDamageable>().TakeDamage(damage);

        Destroy(this.gameObject, 0.5f);

    }
    
   

}
