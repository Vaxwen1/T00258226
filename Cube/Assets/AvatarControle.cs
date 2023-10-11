using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarControle : MonoBehaviour
{
    public GameObject snowballCloneTemplate;
    float currentSpeed, walkingSpeed = 2, runningSpeed = 4;
    private float turningSpeed=180;
    public float jumpSpeed;

    private float ySpeed;
    Animator MyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkingSpeed;
        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MyAnimator.SetBool("iswalking", false);
        MyAnimator.SetBool("walkBack", false);


        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (Input.GetButtonDown("Jump")) 
        {
            ySpeed = jumpSpeed;
        }

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

    }
}
