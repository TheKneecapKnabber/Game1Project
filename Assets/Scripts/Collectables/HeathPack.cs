using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HeathPack : MonoBehaviour, ICollectable, IRecovery 
{
    public int recoverHealth;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            //find player to get components later in the script
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("found player");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnPickup();
        }
    }
    public void OnPickup()
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
        player.GetComponent<PlayerHealth>().Heal(a);
    }


}
