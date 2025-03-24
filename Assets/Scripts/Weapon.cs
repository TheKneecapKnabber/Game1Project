using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "ScriptableObjects/Weapon")]
public abstract class Weapon : ScriptableObject
{
    public float damage;
    public int durability;

    public abstract void Attack();
}
