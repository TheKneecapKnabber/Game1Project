using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaycastWeaponBase : WeaponBase
{
    /*
    public override void Fire(Transform shootpoint)
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f , 0f));
        RaycastHit hit;

        Vector3 target;
        if(Physics.Raycast(ray, out hit)) target = hit.point;
        else target = ray.GetPoint(50);
        Vector3 direction = target - shootpoint.position;

    }
    */
}
