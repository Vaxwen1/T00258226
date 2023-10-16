using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VladControle : MonoBehaviour
{
    Rigidbody MyRB;
    // Start is called before the first frame update
    void Start()
    {
        MyRB = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MyRB.AddForce(transform.forward);
            //transform.position += transform.forward * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyRB.AddExplosionForce(10,transform.position+Vector3.down,5);
            //transform.position += transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            transform.Rotate(Vector3.up, 90 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -90 * Time.deltaTime);
        }
    }
}
