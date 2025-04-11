using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealthPack : InstantUseBase, IRecovery 
{
    public int recoverHealth;
    [SerializeField] private PlayerHealth ph;

    void Start()
    {
        if (player == null)
        {
            //find player to get components later in the scripts
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("found player");
            ph = player.GetComponent<PlayerHealth>();
        }
        else
        {
            ph = player.GetComponent<PlayerHealth>();
        }
    }
    
    
    public override void OnPickup()
    {
        Debug.Log("in pickup");
        //on pickup heal player
        Recover(recoverHealth);
        Debug.Log("past recover");
        //could add particles for extra effect

        //after it has been picked up delete or disable
        Destroy(gameObject);

    }

    public void Recover(int a)
    {
        //heal player by recover health value
        ph.Heal(a);
    }


}
