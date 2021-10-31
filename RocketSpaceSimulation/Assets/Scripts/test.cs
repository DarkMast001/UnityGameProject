using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    double new_G;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            new_G = (6.67 * Mathf.Pow(10, -11) * 5.9742 * Mathf.Pow(10, 24)) / (Mathf.Pow(6371000, 2));
            print(new_G);
            //Physics.gravity = new Vector3(0, 1, 0);
        }
    }
}
