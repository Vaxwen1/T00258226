using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float jumpButtonPrassedTime;


    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedtime;
    private float? jumbpButtonPressedTime;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset=characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");



        Vector3 movementDirection= new Vector3 (horizontalInput,0, verticallInput);
        float magnitude = Mathf.Clamp01 (movementDirection.magnitude)*speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedtime= Time.time;

        }
        if (Input.GetButtonDown("Jump")) 
        {
            jumpButtonPrassedTime = Time.time;
        }

        if (Time.time-lastGroundedTime<=jumpButtongracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            if (Input.GetButton("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else 
        {
            characterController.stepOffset = 0;
        }
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;


        characterController.Move(velocity*Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }



    }
}
