using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nAmmoText;
    [SerializeField] private TMP_Text sAmmoText;
    public PlayerAmmo plAmmo;
    public WeaponController wc;

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
    }
    private void UpdateSgAmount(int curSgAmmo)
    {
        nAmmoText.text = ($"{curSgAmmo} / {plAmmo.sAmmo}");
    }
    private void UpdatePistolAmount(int curPistolAmmo)
    {
        nAmmoText.text = ($"{curPistolAmmo} / {plAmmo.nAmmo}");
    }


}
