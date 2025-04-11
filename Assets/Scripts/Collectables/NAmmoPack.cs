using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAmmoPack : InstantUseBase, IRecovery
{
    public int recoverNAmmo;
    [SerializeField] private PlayerAmmo pa;

    void Start()
    {
        if (player == null)
        {
            //find player to get components later in the scripts
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("found player");
            pa = player.GetComponent<PlayerAmmo>();
        }
        else
        {
            pa = player.GetComponent<PlayerAmmo>();
        }
    }
    


    public override void OnPickup()
    {
        Recover(recoverNAmmo);

        //particles if you want

        Destroy(gameObject);
    }
    public void Recover(int a)
    {
        //heal player by recover health value
        pa.GetNAmmo(a);
    }
}
