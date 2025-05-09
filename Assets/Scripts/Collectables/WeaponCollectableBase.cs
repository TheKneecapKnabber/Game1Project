using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponCollectableBase : CollectableBase
{
    protected WeaponController wc;
    protected PlayerAmmo plAmmo;

    void Start()
    {
        if (player == null)
        {
            //find player to get components later in the scripts
            player = GameObject.FindGameObjectWithTag("Player");
            //Debug.Log("found player");
            wc = player.GetComponent<WeaponController>();
            plAmmo = player.GetComponent<PlayerAmmo>();
        }
        else
        {
            wc = player.GetComponent<WeaponController>();
            plAmmo = player.GetComponent<PlayerAmmo>();
        }
    }
    

    public override void OnPickup()
    {
        Equip();
        Destroy(gameObject);
    }
    public abstract void Equip();
}

