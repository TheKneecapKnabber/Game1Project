using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMachineGun : WeaponCollectableBase
{
    [SerializeField] private GameObject MachineGunPreFab;
    [SerializeField] private int giveAmmo = 20; //give ammo should be clip size





    public override void Equip()
    {
        if (wc.hasMachineGun)//has pistol is a bool
        {
            //give normal ammo
            player.GetComponent<PlayerAmmo>().GetNAmmo(giveAmmo);
            Debug.Log("give ammo");

        }
        else
        {
            // give pistol prefab to wc "weapon" in slot whatever
            Debug.Log("gave pistol");
            wc.weapons[1] = MachineGunPreFab;
            //give normal ammo
            player.GetComponent<PlayerAmmo>().GetNAmmo(giveAmmo);
            wc.hasMachineGun = true;
        }
    }
}
