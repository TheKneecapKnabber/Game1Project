using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GroundedTrigger : MonoBehaviour
{
    public bool grounded;

    void OnTriggerEnter(Collider other)
    {
        grounded = true;
    }
    void OnTriggerExit(Collider other)
    {
        grounded = false;
    }
}
