using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nAmmoText;
    [SerializeField] private TMP_Text sAmmoText;

    private void OnEnable()
    {
        PlayerAmmo.OnNAmmoChange += UpdateNAmmoUI;
        PlayerAmmo.OnSAmmoChange += UpdateSAmmoUI;
    }
    private void OnDisable()
    {
        PlayerAmmo.OnNAmmoChange -= UpdateNAmmoUI;
        PlayerAmmo.OnSAmmoChange -= UpdateSAmmoUI;
    }

    private void UpdateNAmmoUI(int newNAmmo)
    {
        if (newNAmmo == 0)
        {
            nAmmoText.enabled = false;
        }
        else
        {
            nAmmoText.enabled = true;
            nAmmoText.text = ($"Regular ammo: {newNAmmo}");
        }
    }

    private void UpdateSAmmoUI(int newSAmmo)
    {
        if(newSAmmo == 0)
        {
            sAmmoText.enabled = false;
        }
        else
        {
            sAmmoText.enabled = true;
            sAmmoText.text = ($"Shotgun ammo: {newSAmmo}");
        }
    }

}
