using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarControle : MonoBehaviour
{
   
    public GameObject snowballCloneTemplate;
    public float currentSpeed,walkingSpeed = 10, runningSpeed=20;
    private float turningSpeed = 180;
    private float ySpeed;
    public float jumpForce =7f;
    public float gravity = 1;
    Animator MyAnimator;
    public Rigidbody rb;
    public bool onTheGround = true;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkingSpeed;
        MyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        MyAnimator.SetBool("iswalking", false);
        MyAnimator.SetBool("walkBack", false);
        MyAnimator.SetBool("isJump", false);
        MyAnimator.SetBool("isRun", false);


        ySpeed += Physics.gravity.y * Time.deltaTime;

        
        if (Input.GetKey(KeyCode.W)) 
        {
            MyAnimator.SetBool("iswalking", true);
            transform.position +=currentSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MyAnimator.SetBool("walkBack", true);
            transform.position -= currentSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up,turningSpeed* Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up,-turningSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            GameObject newGO = Instantiate(snowballCloneTemplate);
            SnowballControl mySnowball = newGO.GetComponent<SnowballControl>();

            mySnowball.ImThowingYou(this);
        }
        if (Input.GetKeyDown(KeyCode.Space) && onTheGround) 
        {
            MyAnimator.SetBool("isJump", true);
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            onTheGround = false;
        }
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            onTheGround = true;
        }
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            MyAnimator.SetBool("isRun", true);
            currentSpeed = runningSpeed;
           
        }
      
    }

    
}

