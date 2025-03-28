using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
    public static event Action Shoot;
    public static event Action StopShoot;
    public static event Action Delete;
    public static event Action Reload;
    public GameObject selectedWeapon;
    [SerializeField] private GameObject WeaponPoint;
    public Transform shootPoint;
    public Transform WeaponPos;
    public GameObject ProjectilePrefab;
    public GameObject[] weapons = new GameObject[3];
    private GameObject currGun;
    public bool hasPistol, hasMachineGun, hasShotgun = false;
    // Start is called before the first frame update
    void Start()
    {
        if (WeaponPoint == null)
        {
            WeaponPoint = GameObject.FindGameObjectWithTag("WeaponPoint");
        }
        WeaponPos = WeaponPoint.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (weapons[0] != null && selectedWeapon != weapons[0])
            {
                if (selectedWeapon == null) Delete.Invoke();
                selectedWeapon = weapons[0];
                Debug.Log("Switched to " + selectedWeapon.name);
                Instantiate(selectedWeapon, WeaponPos);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(weapons[1] != null && selectedWeapon != weapons[1])
            {
                if (selectedWeapon == null) Delete.Invoke();
                selectedWeapon = weapons[1];
                Debug.Log("Switched to " + selectedWeapon.name);
                Instantiate(selectedWeapon, WeaponPos);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weapons[2] != null && selectedWeapon != weapons[2])
            {
                if (selectedWeapon == null) Delete.Invoke();
                selectedWeapon = weapons[2];
                Debug.Log("Switched to " + selectedWeapon.name);
                Instantiate(selectedWeapon, WeaponPos);
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
            Reload?.Invoke();
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
