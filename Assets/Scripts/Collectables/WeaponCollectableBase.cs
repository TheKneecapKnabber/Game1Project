using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponCollectableBase : CollectableBase
{
    protected WeaponController wc;
    protected PlayerAmmo plAmmo;
    public GameObject weaponPic, selectedWeapon;

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
        weaponPic.SetActive(true);
        if (selectedWeapon.activeSelf != true)
        {
            selectedWeapon.SetActive(true);
            selectedWeapon.transform.position = weaponPic.transform.position;
        }
        Equip();
        Destroy(gameObject);
    }
    public abstract void Equip();
}

