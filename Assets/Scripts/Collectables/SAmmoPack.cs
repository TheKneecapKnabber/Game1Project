using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAmmoPack : MonoBehaviour, ICollectable, IRecovery
{
    public int recoverSAmmo;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            //find player to get components later in the script
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("found player");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnPickup();
        }
    }
    public void OnPickup()
    {
        Recover(recoverSAmmo);

        //particles if you want

        Destroy(gameObject);
    }
    public void Recover(int a)
    {
        //heal player by recover health value
        player.GetComponent<PlayerAmmo>().GetSAmmo(a);
    }
}
