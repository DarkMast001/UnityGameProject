using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabilizerControll : MonoBehaviour
{
    Rigidbody rb;
    //public GameObject shuttleSettings;
    private ParticleSystem part;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        part = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {  
        if (Input.GetKey(KeyCode.W) && gameObject.tag == "Down")
        {
            part.Play();
            rb.AddForce(-gameObject.transform.forward * 50);
        }
        else if (Input.GetKey(KeyCode.S) && gameObject.tag == "Up")
        {
            part.Play();
            rb.AddForce(-gameObject.transform.forward * 50);
        }
        else if (Input.GetKey(KeyCode.D) && gameObject.tag == "Left")
        {
            part.Play();
            rb.AddForce(-gameObject.transform.forward * 50);
        }
        else if (Input.GetKey(KeyCode.A) && gameObject.tag == "Right")
        {
            part.Play();
            rb.AddForce(-gameObject.transform.forward * 50);
        }

        else if (Input.GetKey(KeyCode.UpArrow) && gameObject.tag == "DownE")
        {
            part.Play();
            rb.AddForce(-gameObject.transform.forward * 50);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && gameObject.tag == "UpE")
        {
            part.Play();
            rb.AddForce(-gameObject.transform.forward * 50);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && gameObject.tag == "LeftE")
        {
            part.Play();
            rb.AddForce(-gameObject.transform.forward * 50);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && gameObject.tag == "RightE")
        {
            part.Play();
            rb.AddForce(-gameObject.transform.forward * 50);
        }
        else
        {
            part.Stop();
        }
    }
}
