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
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3 (0,20,-40);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ImThowingYou(AvatarControle avatarControle)
    {
        transform.position =avatarControle.transform.position + 2 * Vector3.up + 3 * avatarControle.transform.forward;
        rb=rb.GetComponent<Rigidbody>();
        rb.velocity = 10 * (2 * Vector3.up + 3 * avatarControle.transform.forward);
    }
}
