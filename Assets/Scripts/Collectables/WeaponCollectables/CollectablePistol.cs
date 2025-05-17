using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectablePistol : WeaponCollectableBase
{
    //WeaponController inv = WeaponCollectableBase.wc;

    
    [SerializeField] private GameObject pistolPreFab;
    public AmmoUI2 inventory;
    [SerializeField] private int giveAmmo = 10; //give ammo should be clip size





    public override void Equip()
    {
        if (wc.hasPistol)//has pistol is a bool
        {
            //give normal ammo
            player.GetComponent<PlayerAmmo>().GetNAmmo(giveAmmo);
            Debug.Log("give ammo");
            
        }
        else
        {
            // give pistol prefab to wc "weapon" in slot whatever
            Debug.Log("gave pistol");
            wc.weapons[0] = pistolPreFab;
            //give normal ammo
            player.GetComponent<PlayerAmmo>().GetNAmmo(giveAmmo);
            wc.hasPistol = true;
            if(wc.currentWeapon == null)
            {
                inventory.weaponName.text = "Pistol";
                plAmmo.pistolAmmo += 10;
                wc.selectedWeapon = wc.weapons[0];
                wc.currentWeapon = Instantiate(wc.selectedWeapon, wc.WeaponPos);
                plAmmo.UpdatePistol();
            }
        }
    }
}
