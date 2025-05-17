using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public GroundedTrigger gt;
    private float speed;

    public float walkSpeed, runSpeed, crouchSpeed, sensitivity, maxForce, jumpForce, gravity;

    private bool crouching;

    private float lookRot;
    private Vector2 move, look;
    private Rigidbody rb;
    private Camera cam;
    public bool isInMenu;

    private void Start()
    {
        isInMenu = false;
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        speed = walkSpeed;
        crouching = false;
        //trigger script is on sphere child object
        gt = transform.GetComponentInChildren<GroundedTrigger>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!isInMenu)
        {
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");

            look.x = Input.GetAxis("Mouse X");
            look.y = Input.GetAxis("Mouse Y");

            //jumping
            if (gt.grounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(Vector3.up * jumpForce);
                }
            }

            //crouch
            if (Input.GetKeyDown(KeyCode.LeftControl))//enter crouch
            {
                speed = crouchSpeed;
                crouching = true;
                transform.localScale = new Vector3(1f, 0.5f, 1f);
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))//leave crouch
            {
                speed = walkSpeed;
                crouching = false;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (!crouching)//to prevent sprint speed while crouching
                           //jumping isn't required to go in here so we can have move interesting vents
            {

                //sprint
                if (Input.GetKeyDown(KeyCode.LeftShift))//enter
                {
                    speed = runSpeed;

                }
                if (Input.GetKeyUp(KeyCode.LeftShift))//leave
                {
                    speed = walkSpeed;
                }
            }
        }

    }

    private void FixedUpdate()
    {
        if (!isInMenu)
        {
            Vector3 currVelocity = rb.velocity;
            Vector3 targetVelocity = new Vector3(move.x, 0, move.y) * speed;

            targetVelocity = transform.TransformDirection(targetVelocity);
            Vector3 velocityChange = targetVelocity - currVelocity;

            Vector3.ClampMagnitude(velocityChange, maxForce);

            rb.AddForce(new Vector3(velocityChange.x, 0, velocityChange.z), ForceMode.VelocityChange);
            rb.AddForce(Vector3.down * gravity * rb.mass);
        }

    }

    private void LateUpdate()
    {
        if (!isInMenu)
        {
            transform.Rotate(Vector3.up * look.x * sensitivity);

            lookRot += (-look.y * sensitivity);

            lookRot = Mathf.Clamp(lookRot, -90, 90);

            cam.transform.eulerAngles = new Vector3(lookRot,
            cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
        }
    }
    
}
