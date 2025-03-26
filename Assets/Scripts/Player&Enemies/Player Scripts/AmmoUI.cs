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
    }
    private void OnDisable()
    {
        
    }

    private void UpdateNAmmoUI(int newNAmmo)
    {
        if (newNAmmo == 0)
        {
            sAmmoText.enabled = false;
        }
        else
        {
            sAmmoText.enabled = true;
            sAmmoText.text = ($"Regular ammo: {newNAmmo}");
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
