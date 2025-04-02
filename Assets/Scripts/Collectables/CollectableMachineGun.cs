using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMachineGun : WeaponCollectableBase
{
    [SerializeField] private GameObject MachineGunPreFab;
    [SerializeField] private int giveAmmo = 30; //give ammo should be clip size

    public GameObject mgImage, curImage;

    public override void Equip()
    {
        if (wc.hasMachineGun)//has pistol is a bool
        {
            //give normal ammo
            plAmmo.GetNAmmo(giveAmmo);
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
            mgImage.SetActive(true);
            if(wc.currentWeapon == null)
            {  
                curImage.SetActive(true);
                curImage.transform.position = mgImage.transform.position;
                plAmmo.mgAmmo += 20;
                wc.selectedWeapon = wc.weapons[1];
                wc.currentWeapon = Instantiate(wc.selectedWeapon, wc.WeaponPos);
                plAmmo.UpdateMachinegun();
            }
        }
    }
}
