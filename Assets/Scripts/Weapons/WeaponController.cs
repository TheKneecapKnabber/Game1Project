using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public WeaponBase myWeapon;
    public Transform shootPoint;
    public GameObject ProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        myWeapon = new Gun(new RaycastBehavior());
        myWeapon.shootpoint = shootPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("behavior set to raycast!");
            myWeapon.SetWeaponBehavior(new RaycastBehavior());

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("behaveior set to Projectile!");
            myWeapon.SetWeaponBehavior(new ProjectileBehavior { projectilePrefab = ProjectilePrefab });
        }
        if (Input.GetMouseButtonDown(0))
        {
            myWeapon.Use();
            
        }
    }
}
