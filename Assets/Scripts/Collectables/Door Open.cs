using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : CollectableBase
{
    public Collector Collector;
    public bool isOpen;
    public Animator animator;
    public AnimationClip clip;
    public GameObject keyInventory;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            Debug.Log("open door");
            animator.Play(clip.name);
            keyInventory.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Collector.hasKey)
        {
            isOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isOpen = false;
    }

    public override void OnPickup()
    {
        if (isOpen)
        {
            Debug.Log("open door");
            animator.Play(clip.name);
            keyInventory.SetActive(false);
        }
    }
}
