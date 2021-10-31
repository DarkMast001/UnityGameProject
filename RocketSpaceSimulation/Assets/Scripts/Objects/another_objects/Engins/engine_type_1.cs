using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engine_type_1 : Engin
{
    double Fuel_consumtion_engine = fuel_consumtion_engine;

    GameObject center_point;

    private void Start()
    {
        //print(Fuel_consumtion_engine);
        center_point = GameObject.FindGameObjectWithTag("Center");
        center_point.GetComponent<Shuttle_settings>().weight_modules += gameObject.GetComponent<Rigidbody>().mass;
    }

    private void Update()
    {
        //print(Fuel_consumtion_engine * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
        {
            center_point.GetComponent<Shuttle_settings>().Current_fuel -= Fuel_consumtion_engine * Time.deltaTime;
        }
    }
}
