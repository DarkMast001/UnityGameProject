using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Numeratic_parametors : MonoBehaviour
{
    public Text speed;
    public Text height;
    public Text fuel_quantity;

    public Rigidbody rb_for_speed;
    public GameObject haight_obj;

    public double speed_doub;
    public double haight_doub;
    public double fuel_quantity_doub;

    private void Update()
    {
        if (rb_for_speed != null)
        {
            speed_doub = rb_for_speed.velocity.magnitude;
            speed.text = "Speed: " + (int)speed_doub;
            height.text = "Haight: " + (int)transform.position.y;
        }
    }
}
