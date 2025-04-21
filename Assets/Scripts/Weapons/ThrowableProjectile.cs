using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableProjectile : projectileBase
{
    protected override void OnCollisionEnter(Collision other)
    {
        if (other.collider != null && other.collider.gameObject.GetComponent<IDamageable>() != null)
        {
            DealDamage(other);
        }
        transform.SetParent(other.transform,  true);
    }
 
}
