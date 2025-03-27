using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase 
{
    private GameObject player;

    private void OnEnable()
    {
        //WeaponController.Shoot += Use();
    }
    void OnDisable()
    {
        //WeaponController.Shoot -= Use();
    }




    public void Fire(Transform shootPoint)
    {
        RaycastHit hit;

        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit))
        {
            Debug.Log("Hit " + hit.collider.name);
        }
    }
    

}
