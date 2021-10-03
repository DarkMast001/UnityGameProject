using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructing : MonoBehaviour
{

    public GameObject[] bodyObjects;

    void Update()
    {
        int x = 0, y = 0, z = 0;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(bodyObjects[0], new Vector3(x, y, z), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(bodyObjects[1], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
