using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStart : Engin
{
    Rigidbody rb;
    GameObject center_point;
    public ParticleSystem part;
    double thrust;

    private void Start()
    {
        if (gameObject.GetComponent<engine_type_1>())
        {
            thrust = Thrust;
        }
        else if (gameObject.GetComponent<engine_type_2>())
        {
            thrust = Thrust * 1.8;
        }
        rb = gameObject.GetComponent<Rigidbody>();
        center_point = GameObject.FindGameObjectWithTag("Center");
        part = gameObject.GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q) && center_point.GetComponent<Shuttle_settings>().Current_fuel > 0)
        {
            part.Play();
            rb.AddForce(-gameObject.transform.forward * (int)thrust);
        }
        else
        {
            part.Stop();
        }
    }
}
