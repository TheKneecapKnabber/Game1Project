using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : RaycastWeaponBase 
{
    private GameObject player;

   
    public override void Fire(Transform shootPoint)
    {
        RaycastHit hit;

        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit))
        {
            Debug.Log("Hit " + hit.collider.name);
        }
        
    }
    

}
