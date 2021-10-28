using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body_type_2 : Body
{
    double Fuel_quantity = fuel_quantity * 1.5;
    double Mass_full_tank = mass_full_tank * 1.3;

    GameObject center_point;

    private void Start()
    {
        center_point = GameObject.FindGameObjectWithTag("Center");
        center_point.GetComponent<Shuttle_settings>().MAX_FUEL += Fuel_quantity;
    }
}
