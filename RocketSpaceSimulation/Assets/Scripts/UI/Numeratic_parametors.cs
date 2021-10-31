using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Numeratic_parametors : MonoBehaviour
{
    public Text speed;
    public Text height;
    public Text fuel_quantity;
    public Text waight;
    public Scrollbar amount_of_fuel;

    public Rigidbody rb_for_speed;
    public GameObject haight_obj;
    public GameObject center_point;

    public double speed_doub;
    double current_amount_of_fuel;
    double total_waight;

    //Phisics components
    double new_G;
    double earth_mass = 6371000;

    private void Update()
    {
        current_amount_of_fuel = amount_of_fuel.value * center_point.GetComponent<Shuttle_settings>().MAX_FUEL;
        if (rb_for_speed != null)
        {
            speed_doub = rb_for_speed.velocity.magnitude;
            speed.text = "Speed: " + (int)speed_doub;
            height.text = "Haight: " + (int)transform.position.y;
            current_amount_of_fuel = center_point.GetComponent<Shuttle_settings>().Current_fuel;
        }
        total_waight = center_point.GetComponent<Shuttle_settings>().weight_modules + center_point.GetComponent<Shuttle_settings>().waight_fuel;
        waight.text = $"Current waight: {total_waight:f1}t";
        fuel_quantity.text = $"Fuel quantity: {current_amount_of_fuel:f1} of " + (int)center_point.GetComponent<Shuttle_settings>().MAX_FUEL;
        center_point.GetComponent<Shuttle_settings>().Current_fuel = current_amount_of_fuel;

        // Change G
        new_G = (6.67 * Mathf.Pow(10, -11) * 5.9742 * Mathf.Pow(10, 24)) / (Mathf.Pow(6371000, 2) + transform.position.y);
        Physics.gravity = new Vector3(0, -(float)new_G, 0);
    }
}
