using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStart : Shuttle_settings
{
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            //print(startModule.name);
            rb.AddForce(gameObject.transform.forward * 13);
        }
    }
}
