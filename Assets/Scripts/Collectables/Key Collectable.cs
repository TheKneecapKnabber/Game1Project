using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollectable : CollectableBase, ICollectable
{
    public GameObject keyInventory;
    public Sprite keySprite;
    public Collector collector;
    public override void OnPickup()
    {
        keyInventory.SetActive(true);
        keyInventory.GetComponent<Image>().sprite = keySprite;
        gameObject.SetActive(false);
        collector.hasKey = true;
    }
}
