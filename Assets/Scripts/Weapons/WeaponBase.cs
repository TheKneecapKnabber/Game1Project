using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] public Transform shootpoint { get; private set; }

    public PlayerAmmo playerAmmo;

    public float fireRate, reloadTime;
    public int magazineSize, shotsLeft;
    public int damage;
    

    public Camera cam;
    public Transform target;

    
    
    public IWeaponBehavior weaponBehavior;
    private void Start()
    {
        cam = Camera.main;
    }

    private void OnEnable()
    {
       // WeaponController.Shoot += Use;
        //WeaponController.Reload += CanReload;
        WeaponController.Delete += Despawn;
    }
    private void OnDisable()
    {
        //WeaponController.Shoot -= Use;
        //WeaponController.Reload -= CanReload;
        WeaponController.Delete -= Despawn;
    }

   
    protected void CanReload()
    {

    }
    //public abstract void Fire(Transform shootpoint);
    
    private void Reload()
    {
       
        StartCoroutine(Reloading(reloadTime));
    }
    private IEnumerator Reloading(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        if(magazineSize > shotsLeft)
        {
            shotsLeft = magazineSize;
        }
        
    }
    protected void Despawn()
    {
        Destroy(this.gameObject);
    }

    
}
