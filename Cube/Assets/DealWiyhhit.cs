using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWiyhhit : MonoBehaviour
{
    int  Health = 100;
    internal void IHitYou() 
    {
        Health -= 20;
        if (Health < 50) 
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        if (Health < 0) 
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
