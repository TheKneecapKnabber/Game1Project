using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Axe", menuName = "Scriptable Objects/Weapons/Axe")]
public class Axe : Weapon, IDamageable, IMeleeable, IThrowable
{
    public override void Attack()
    {
        Debug.Log("Axe was used.");
    }
    public void TakeDamage(int damage)
    {
        durability -= damage;
    }

    public void Melee()
    {
        Debug.Log("Axe was meleed with");
    }

    public void Throw()
    {
        Debug.Log("Axe was thrown");
    }
}
