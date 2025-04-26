using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAntagonistEvent : MonoBehaviour
{
    public Camera camera;
    public GameObject newCam;
    public GameObject oldCam;
    public GameObject player;
    public GameObject target;
    private void Awake()
    {
        newCam.GetComponent<Camera>().enabled = true;
        oldCam.GetComponent<Camera>().enabled = false;
        camera = Camera.main;
        player.transform.position = target.transform.position;
        player.transform .rotation = target.transform.rotation;
    }

}
