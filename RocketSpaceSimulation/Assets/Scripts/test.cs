using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public ParticleSystem part;

    void Start()
    {
        part = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            part.Play();
        }
        else
        {
            part.Stop();
        }
    }
}
