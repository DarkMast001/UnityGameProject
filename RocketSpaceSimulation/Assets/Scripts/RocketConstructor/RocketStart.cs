using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStart : MonoBehaviour
{
    Rigidbody rb;
    GameObject engin_characters;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //engin_characters = GetComponent<En>
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            //print(startModule.name);
            rb.AddForce(gameObject.transform.forward * 10);
        }
    }
}
