using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableShotgun : WeaponCollectableBase
{
    [SerializeField] private GameObject shotgunPreFab;
    [SerializeField] private int giveAmmo = 5; //give ammo should be clip size

    public GameObject shotgunImage, curImage;



    public override void Equip()
    {
        if (wc.hasShotgun)//has pistol is a bool
        {
            //give normal ammo
            player.GetComponent<PlayerAmmo>().GetSAmmo(giveAmmo);
            Debug.Log("give ammo");

        }
        else
        {
            // give pistol prefab to wc "weapon" in slot whatever
            Debug.Log("Gave Shotgun");
            wc.weapons[2] = shotgunPreFab;
            //give shotgun ammo
            player.GetComponent<PlayerAmmo>().GetSAmmo(giveAmmo);
            wc.hasShotgun = true;
            shotgunImage.SetActive(true);
            if(wc.currentWeapon == null)
            {
                curImage.SetActive(true);
                curImage.transform.position = shotgunImage.transform.position;
                plAmmo.shotgunAmmo += 5;
                wc.selectedWeapon = wc.weapons[2];
                wc.currentWeapon = Instantiate(wc.selectedWeapon, wc.WeaponPos);
                plAmmo.UpdateShotgun();
            }
        }
    }
}
