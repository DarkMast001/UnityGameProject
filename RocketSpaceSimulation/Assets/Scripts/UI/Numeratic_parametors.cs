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

    public double speed_doub;
    int current_amount_of_fuel;
    int max_fuel = 3000;

    private void Update()
    {
        current_amount_of_fuel = (int)(amount_of_fuel.value * max_fuel);
        if (rb_for_speed != null)
        {
            speed_doub = rb_for_speed.velocity.magnitude;
            speed.text = "Speed: " + (int)speed_doub;
            height.text = "Haight: " + (int)transform.position.y;
        }
        fuel_quantity.text = "Fuel quantity: " + current_amount_of_fuel + " of " + max_fuel;
    }
}
