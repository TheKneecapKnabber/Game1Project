using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest : MonoBehaviour
{
    /*
    private delegate void Example(int x);
    private Example _myDelegate;

    public delegate void OnDeath();
    public static event OnDeath _myDeath;
    

    [SerializeField] private int health = 100;
    public int damageAmt = 10;

    

    private void OnEnable()
    {
        _myDelegate += TakeDamage;
       
    }

    private void OnDisable()
    {
        _myDelegate -= TakeDamage;
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _myDelegate?.Invoke(damageAmt);
            if (health <= 0 )
            {
                _myDeath?.Invoke();
                _myAction?.Invoke();
            }
        }

    }

    private void TakeDamage(int x)
    {
        health -= x;
        Debug.Log("health: " + health);
    }
    */

}
