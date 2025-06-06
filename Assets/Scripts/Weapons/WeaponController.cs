using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    
    public static event Action Shoot;
    public static event Action StopShoot;
    //public static event Action Delete;
    //public static event Action Reload;
    public GameObject selectedWeapon;
    [SerializeField] private GameObject WeaponPoint;
    public Transform shootPoint;//grab shootpoint from gun
    public Transform WeaponPos;//position where weapon spawns
    public GameObject ProjectilePrefab;
    public GameObject[] weapons = new GameObject[4];
    public bool hasPistol, hasMachineGun, hasShotgun, hasThrowable = false;
    public GameObject currentWeapon;
    public PlayerAmmo plAmmo;//needed to call info from player ammo
    public GameObject pistolUI, shotgunUI, mgUI, selectedWepUI;
    public AmmoUI2 inventory;

    void Start()
    {
        if (WeaponPoint == null)
        {
            WeaponPoint = GameObject.FindGameObjectWithTag("WeaponPoint");//grabs the default point on the player
        }
        WeaponPos = WeaponPoint.transform;
        currentWeapon = null;
        if (plAmmo == null)
        {
            plAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAmmo>();
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (weapons[0] != null && selectedWeapon != weapons[0])
            {
                //if (selectedWeapon == null) Delete.Invoke();
                if(selectedWeapon !=weapons[0]) Destroy(currentWeapon);
                selectedWeapon = weapons[0];
                Debug.Log("Switched to " + selectedWeapon.name);
                currentWeapon = Instantiate(selectedWeapon, WeaponPos);
                plAmmo.UpdatePistol();
                selectedWepUI.transform.position = pistolUI.transform.position;
                inventory.weaponName.text = "Pistol";
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(weapons[1] != null && selectedWeapon != weapons[1])
            {
                //if (selectedWeapon == null) Delete.Invoke();
                if(selectedWeapon !=weapons[1]) Destroy(currentWeapon);
                selectedWeapon = weapons[1];
                Debug.Log("Switched to " + selectedWeapon.name);
                currentWeapon = Instantiate(selectedWeapon, WeaponPos);
                plAmmo.UpdateMachinegun();
                selectedWepUI.transform.position = mgUI.transform.position;
                inventory.weaponName.text = "Machine Gun";
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weapons[2] != null && selectedWeapon != weapons[2])
            {
                //if (selectedWeapon == null) Delete.Invoke();
                if(selectedWeapon !=weapons[2]) Destroy(currentWeapon);
                selectedWeapon = weapons[2];
                Debug.Log("Switched to " + selectedWeapon.name);
                currentWeapon = Instantiate(selectedWeapon, WeaponPos);
                plAmmo.UpdateShotgun();
                selectedWepUI.transform.position = shotgunUI.transform.position;
                inventory.weaponName.text = "Shotgun";
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (weapons[3] != null && selectedWeapon != weapons[3] && hasThrowable)
            {
                //if (selectedWeapon == null) Delete.Invoke();
                if (selectedWeapon != weapons[3]) Destroy(currentWeapon);
                selectedWeapon = weapons[3];
                Debug.Log("Switched to " + selectedWeapon.name);
                currentWeapon = Instantiate(selectedWeapon, WeaponPos);
                plAmmo.UpdateThrowable();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot?.Invoke();
        }
        if(Input.GetMouseButtonUp(0))
        {
            StopShoot?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentWeapon.GetComponent<IReloadable>().Reload();
        }
    }
    public void SetSelectedWeapon(GameObject a)
    {
        selectedWeapon = a;
    }
    /*
    private void ChangeShootPoint() 
    {
        shootPoint = selectedWeapon.GetComponent<WeaponBase>().shootPoint.Value;
    }
    */


}
