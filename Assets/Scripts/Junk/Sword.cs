using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Sword", menuName = "Scriptable Objects/Weapons/Sword")]
public class Sword : Weapon, IDamageable, IMeleeable 
{
    public override void Attack()
    {
        Debug.Log("Sword was used.");
    }

    public void ReduceDurablility(int damage)
    {
        durability -= damage;
    }

    public void Melee()
    {
        Debug.Log("Sword was meleed with");
    }
}
