using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Collector : MonoBehaviour
{
    
    [SerializeField] private Transform collectorSouce;
    public TMP_Text itemText;
    
    public float collectorRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, collectorRange))

        {
            if(hit.collider.gameObject.tag == "Collectable")
            {
                itemText.enabled = true;
                itemText.text = hit.collider.gameObject.name;
                //Debug.Log(hit.collider.gameObject.name);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<CollectableBase>().OnPickup();
                }
            }
            
            

            
        }
        else
        {
            if(itemText.enabled)
            {
                itemText.enabled = false;
            }
        }



    }
}
