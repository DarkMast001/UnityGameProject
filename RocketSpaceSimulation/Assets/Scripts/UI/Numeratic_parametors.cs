using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Numeratic_parametors : MonoBehaviour
{
    public Text speed;
    public Text height;
    public Text fuel_quantity;
    public Scrollbar amount_of_fuel;

    public Rigidbody rb_for_speed;
    public GameObject haight_obj;
    public GameObject center_point;

    public double speed_doub;
    int current_amount_of_fuel;

    private void Update()
    {
        current_amount_of_fuel = (int)(amount_of_fuel.value * center_point.GetComponent<Shuttle_settings>().MAX_FUEL);
        if (rb_for_speed != null)
        {
            speed_doub = rb_for_speed.velocity.magnitude;
            speed.text = "Speed: " + (int)speed_doub;
            height.text = "Haight: " + (int)transform.position.y;
            current_amount_of_fuel = (int)center_point.GetComponent<Shuttle_settings>().Current_fuel;
        }
        fuel_quantity.text = "Fuel quantity: " + current_amount_of_fuel + " of " + center_point.GetComponent<Shuttle_settings>().MAX_FUEL;
        center_point.GetComponent<Shuttle_settings>().Current_fuel = current_amount_of_fuel;
    }
}
