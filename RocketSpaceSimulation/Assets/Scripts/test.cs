using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject obj;
    Rigidbody rb;
    void Start()
    {
        rb = obj.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(obj.transform.up * 15);
        }
        if (Input.GetKeyDown(KeyCode.W) && transform.gameObject.GetComponent<FixedJoint>() == null)
        {
            transform.gameObject.AddComponent<FixedJoint>();
        }
    }
}
