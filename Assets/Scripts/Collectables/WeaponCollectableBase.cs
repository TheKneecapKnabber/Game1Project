using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponCollectableBase : CollectableBase
{
    protected WeaponController wc;

    void Start()
    {
        if (player == null)
        {
            //find player to get components later in the scripts
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("found player");
            wc = player.GetComponent<WeaponController>();
        }
    }

    private void OnEnable()
    {
        Collector.Collect += OnPickup;

    }
    private void OnDisable()
    {
        Collector.Collect -= OnPickup;
    }

    public override void OnPickup()
    {
        Equip();
        Destroy(gameObject);
    }
    public abstract void Equip();
}

