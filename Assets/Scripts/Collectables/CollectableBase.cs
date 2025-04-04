using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableBase : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        if (player == null)
        {
            //find player to get components later in the scripts
            player = GameObject.FindGameObjectWithTag("Player");
            //Debug.Log("found player");
        }
    }
    public abstract void OnPickup();
}
