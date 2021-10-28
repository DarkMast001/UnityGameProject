using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engine_type_2 : Engin
{
    double Fuel_consumtion_engine = fuel_consumtion_engine * 1.1;

    GameObject center_point;

    private void Start()
    {
        center_point = GameObject.FindGameObjectWithTag("Center");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            center_point.GetComponent<Shuttle_settings>().Current_fuel -= Fuel_consumtion_engine * Time.deltaTime;
        }
    }
}
