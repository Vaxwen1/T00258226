using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class SnowballControl : MonoBehaviour
{
    Rigidbody rb;
    internal int check = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Ouch");

        DealWithHit thingIHit= collision.gameObject.GetComponent<DealWithHit>();
        if (thingIHit != null ) 
        {
            thingIHit.IHitYou();
        }
    }

    internal void ImThowingYou(AvatarControle avatarControle)
    {
        transform.position =avatarControle.transform.position + 1  * Vector3.up + 1 * avatarControle.transform.forward;
        rb=GetComponent<Rigidbody>();
        rb.velocity = 4 * (2 * Vector3.up + 3 * avatarControle.transform.forward);
    }
}





//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.ShortcutManagement;
//using UnityEngine;

//public class SnowballControl : MonoBehaviour
//{
//    Rigidbody rb;
//    internal int check = 0;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        print("Ouch");

//        DealWithHit thingIHit = collision.gameObject.GetComponent<DealWithHit>();
//        if (thingIHit != null)
//        {
//            thingIHit.IHitYou();
//        }
//    }

//    internal void ImThowingYou(AvatarControle avatarControle)
//    {
//        transform.position = avatarControle.transform.position + 1 * Vector3.up + 1 * avatarControle.transform.forward;
//        rb = GetComponent<Rigidbody>();
//        rb.velocity = 4 * (2 * Vector3.up + 3 * avatarControle.transform.forward);
//    }
//}
