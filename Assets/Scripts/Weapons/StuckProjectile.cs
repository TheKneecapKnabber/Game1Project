using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckProjectile : MonoBehaviour
{
    [SerializeField] float stayTime = 8f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, stayTime);
    }

   
}
