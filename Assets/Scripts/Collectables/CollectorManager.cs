using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorManager : MonoBehaviour
{
    public GameObject player;
    public static CollectorManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        if (player == null)
        {
            player = this.gameObject;
        }
    }
   
}
