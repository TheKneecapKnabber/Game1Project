using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName ="ScriptableObjects/Gun")]
public abstract class Gun : ScriptableObject
{
    public float damage;
    public int ammo;
    public float reloadtime;
    

    public abstract void Shot();
}
