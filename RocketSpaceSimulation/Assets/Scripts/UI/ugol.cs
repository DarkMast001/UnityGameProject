using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ugol : MonoBehaviour
{
    float x, y, z;
    float temp_x = 0, temp_y = 0, temp_z = 0;
    float rez_x, rez_y, rez_z;
    float lenght;
    float angle;
    public GameObject rot;

    void FixedUpdate()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
        rez_x = x - temp_x;
        rez_y = y - temp_y;
        rez_z = z - temp_z;
        lenght = Mathf.Sqrt((rez_x * rez_x) + (rez_y * rez_y) + (rez_z * rez_z));
        if (lenght == 0)
        {
            angle = 0;
        }
        else
        {
            angle = (float)(Mathf.Acos(rez_y / lenght) * 57.2958);
        }
        rot.transform.rotation = Quaternion.AngleAxis(angle,Vector3.right);
        temp_x = x;
        temp_y = y;
        temp_z = z;
    }
}
