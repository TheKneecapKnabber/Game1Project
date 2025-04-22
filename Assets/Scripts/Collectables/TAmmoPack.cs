using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TAmmoPack : InstantUseBase, IRecovery
{
    public int recoverTAmmo;
    [SerializeField] private GameObject throwablePrefab;
    [SerializeField] private PlayerAmmo pa;
    [SerializeField] private WeaponController wc; // needed because the ammo is also the weapon

    void Start()
    {
        if (player == null)
        {
            //find player to get components later in the scripts
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("found player");
            pa = player.GetComponent<PlayerAmmo>();
        }
        else
        {
            wc = player.GetComponent<WeaponController>();
            pa = player.GetComponent<PlayerAmmo>();
        }
    }


    public override void OnPickup()
    {
        Recover(recoverTAmmo);
        wc.hasThrowable = true;
        if (wc.weapons[3] ==  null)
        {
            //gives the weapon prefab
            wc.weapons[3] = throwablePrefab;
        }

        //particles if you want

        Destroy(gameObject);
    }
    public void Recover(int a)
    {
        //Give player ammo
        pa.GetTAmmo(a);
    }
}
