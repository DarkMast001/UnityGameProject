using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            rb.AddForce(0, 10, 0);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(0, 10, 10);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(0, 10, -10);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(10, 10, 0);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(-10, 10, 0);
    }
}
