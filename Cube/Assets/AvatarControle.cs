using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarControle : MonoBehaviour
{
    public GameObject snowballCloneTemplate;
    float currentSpeed, walkingSpeed = 2, runningSpeed = 4;
    private float turningSpeed=180;
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

        if (Input.GetKey(KeyCode.W)) 
        {
            MyAnimator.SetBool("iswalking", true);
            transform.position +=currentSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
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
