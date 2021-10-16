using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_construct : MonoBehaviour
{
    public GameObject[] ship_points;
    public GameObject[] construct_element_points;

    public GameObject ship;
    public GameObject construct_element;

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(ship_points[0].transform.position, construct_element_points[0].transform.position) < 0.35)
        {
            Vector3 ship_point = ship_points[0].transform.position;
            construct_element.transform.position = new Vector3(ship_point.x + 0.5f, ship_point.y, ship_point.z);
            construct_element.transform.parent = ship.transform;
        }
        else
        {
            construct_element.transform.parent = null;
        }
    }
}
