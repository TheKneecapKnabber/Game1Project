using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUser : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();
    public Weapon selectedWeapon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = weapons[0];
            Debug.Log("Switched to " + selectedWeapon.name);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = weapons[1];
            Debug.Log("Switched to " + selectedWeapon.name);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = weapons[2];
            Debug.Log("Switched to " + selectedWeapon.name);
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            if (selectedWeapon is IMeleeable meleeWeapon)
            {
                meleeWeapon.Melee();
                selectedWeapon.Attack();
                if (selectedWeapon is IDamageable damageAble)
                {
                    damageAble.ReduceDurablility(1);
                }
            }

        }
        if(Input.GetMouseButtonDown(1))
        {
            if (selectedWeapon is IThrowable throwable)
            {
                throwable.Throw();
                selectedWeapon.Attack();

                if (selectedWeapon is IDamageable damageAble)
                {
                    damageAble.ReduceDurablility(3);
                }
            }
        }
    }
}
