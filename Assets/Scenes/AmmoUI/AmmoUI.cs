using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nAmmoText;
    [SerializeField] private TMP_Text weaponNameText;
    public PlayerAmmo plAmmo;
    public WeaponController wc;
    public GameObject pistolImage, mgImage, sgImage, curWep;
    public GameObject nBulletImage, sBulletImage;
    private void OnEnable()
    {
        PlayerAmmo.OnNAmmoChange += UpdateNAmmoUI;
        PlayerAmmo.OnSAmmoChange += UpdateSAmmoUI;
        PlayerAmmo.OnMGChange += UpdateMgAmount;
        PlayerAmmo.OnPistolChange += UpdatePistolAmount;
        PlayerAmmo.OnSGChange += UpdateSgAmount;
    }
    private void OnDisable()
    {
        PlayerAmmo.OnNAmmoChange -= UpdateNAmmoUI;
        PlayerAmmo.OnSAmmoChange -= UpdateSAmmoUI;
        PlayerAmmo.OnMGChange -= UpdateMgAmount;
        PlayerAmmo.OnPistolChange -= UpdatePistolAmount;
        PlayerAmmo.OnSGChange -= UpdateSgAmount;
    }

    private void UpdateNAmmoUI(int newNAmmo)
    {
        if(wc.selectedWeapon == wc.weapons[0])
        {
            plAmmo.UpdatePistol();
        }
        else if(wc.selectedWeapon == wc.weapons[1])
        {
            plAmmo.UpdateMachinegun();
        }
    }

    private void UpdateSAmmoUI(int newSAmmo)
    {
        if(wc.selectedWeapon == wc.weapons[0])
        {
            plAmmo.UpdateShotgun();
        }
    }

    private void UpdateMgAmount(int curMgAmmo)
    {
        nAmmoText.text = ($"{curMgAmmo} / {plAmmo.nAmmo}");
        curWep.transform.position = mgImage.transform.position;
        weaponNameText.text = "Machine Gun";
        nBulletImage.SetActive(true);
        sBulletImage.SetActive(false);
    }
    private void UpdateSgAmount(int curSgAmmo)
    {
        nAmmoText.text = ($"{curSgAmmo} / {plAmmo.sAmmo}");
        curWep.transform.position = sgImage.transform.position;
        weaponNameText.text = "Shotgun";
        nBulletImage.SetActive(false);
        sBulletImage.SetActive(true);
    }
    private void UpdatePistolAmount(int curPistolAmmo)
    {
        nAmmoText.text = ($"{curPistolAmmo} / {plAmmo.nAmmo}");
        curWep.transform.position = pistolImage.transform.position;
        weaponNameText.text = "Pistol";
        nBulletImage.SetActive(true);
        sBulletImage.SetActive(false);
    }


}
