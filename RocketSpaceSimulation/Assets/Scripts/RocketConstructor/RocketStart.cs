using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStart : MonoBehaviour
{
    Rigidbody rb;
    GameObject center_point;
    public ParticleSystem part;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        center_point = GameObject.FindGameObjectWithTag("Center");
        part = gameObject.GetComponent<ParticleSystem>();
        //engin_characters = GetComponent<En>
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && center_point.GetComponent<Shuttle_settings>().Current_fuel > 0)
        {
            //print(startModule.name);
            part.Play();
            rb.AddForce(-gameObject.transform.forward * 10);
        }
        else
        {
            part.Stop();
        }
    }
}
