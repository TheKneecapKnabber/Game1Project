using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TargetDummy : MonoBehaviour, IDamageable
{
    public void TakeDamage(int damage)
    {
        Debug.Log("Hit");
    }
}
