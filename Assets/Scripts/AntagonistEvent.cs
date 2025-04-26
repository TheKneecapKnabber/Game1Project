using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntagonistEvent : MonoBehaviour
{
    public Animator animator;
    public GameObject oldCamera;
    public GameObject newCamera;
    public Camera cam;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            oldCamera.GetComponent<Camera>().enabled = false;
            newCamera.GetComponent<Camera>().enabled = true;
            cam = Camera.main;
            animator.Play("AntagonistEvent");
            Destroy(this);
        }
    }
}
