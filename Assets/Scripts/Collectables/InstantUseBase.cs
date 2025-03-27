using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstantUseBase : CollectableBase
{

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnPickup();
        }
    }
    public override void OnPickup()
    {
        Debug.Log ("do something");
        Destroy (gameObject);
    }

}
