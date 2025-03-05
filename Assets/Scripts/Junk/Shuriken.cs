using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shuriken", menuName = "Scriptable Objects/Weapons/Shuriken")]
public class Shuriken : Weapon, IThrowable
{
    public override void Attack()
    {
        Debug.Log("Shriken was used.");
    }

    public void Throw()
    {
        Debug.Log("Shriken was thrown");
    }
}
