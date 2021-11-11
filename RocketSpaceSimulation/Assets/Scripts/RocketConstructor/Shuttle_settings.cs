using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuttle_settings : MonoBehaviour
{
    public List<GameObject> engines = new List<GameObject>();
    public List<GameObject> modules = new List<GameObject>();
    //static protected

    public double MAX_FUEL = 0;
    public double Current_fuel;

    public double weight_modules = 0;
    public double waight_fuel;

    public int surface_area = 0;
    public double aerodynamic_drag;
    private double break_force = 50000;
    public GameObject obj;

    private void FixedUpdate()
    {
        aerodynamic_drag = 0.8 * (1.2041 * Mathf.Pow((float)obj.GetComponent<Numeratic_parametors>().speed_doub, 2) / 2) * surface_area;
        if(aerodynamic_drag > break_force)
        {
            for(int i = 0; i < modules.Count; i++)
            {
                Destroy(modules[i].GetComponent<FixedJoint>());
                Current_fuel = 0;
                waight_fuel = 0;
            }
        }
        waight_fuel = Current_fuel * 0.8;
    }
}
