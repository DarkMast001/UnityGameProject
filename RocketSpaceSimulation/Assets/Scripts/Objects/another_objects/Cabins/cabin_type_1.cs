using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabin_type_1 : MonoBehaviour
{
    GameObject center_point;

    private void Start()
    {
        center_point = GameObject.FindGameObjectWithTag("Center");
        center_point.GetComponent<Shuttle_settings>().weight_modules += gameObject.GetComponent<Rigidbody>().mass;
    }
}
