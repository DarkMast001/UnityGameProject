using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabilizerControll : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && gameObject.tag == "Down") rb.AddForce(-gameObject.transform.forward * 50);
        else if (Input.GetKey(KeyCode.S) && gameObject.tag == "Up") rb.AddForce(-gameObject.transform.forward * 50);
        else if (Input.GetKey(KeyCode.D) && gameObject.tag == "Left") rb.AddForce(-gameObject.transform.forward * 50);
        else if(Input.GetKey(KeyCode.A) && gameObject.tag == "Right") rb.AddForce(-gameObject.transform.forward * 50);
    }
}
