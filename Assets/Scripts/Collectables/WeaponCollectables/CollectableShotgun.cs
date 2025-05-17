using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableShotgun : WeaponCollectableBase
{
    [SerializeField] private GameObject shotgunPreFab;
    public AmmoUI2 inventory;
    [SerializeField] private int giveAmmo = 5; //give ammo should be clip size





    public override void Equip()
    {
        if (wc.hasShotgun)//has ShotGun is a bool that is false by default
        {
            //give Shotgun ammo
            
            player.GetComponent<PlayerAmmo>().GetSAmmo(giveAmmo);
            Debug.Log("give ammo");

        }
        else
        {
            // give pistol prefab to wc "weapon" in slot whatever the designers want
            Debug.Log("Gave Shotgun");
            wc.weapons[2] = shotgunPreFab;
            //give shotgun ammo
            player.GetComponent<PlayerAmmo>().GetSAmmo(giveAmmo);
            wc.hasShotgun = true;
            if(wc.currentWeapon == null)
            {
                inventory.weaponName.text = "Shotgun";
                plAmmo.shotgunAmmo += 5;
                wc.selectedWeapon = wc.weapons[2];
                wc.currentWeapon = Instantiate(wc.selectedWeapon, wc.WeaponPos);
                plAmmo.UpdateShotgun();
            }
        }
    }
}
