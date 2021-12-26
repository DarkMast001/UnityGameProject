using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UgolNew : MonoBehaviour
{
    float rez_x, rez_y, rez_z;
    float lenght;
    float angle;
    public Rigidbody rb;
    public GameObject rot, niz, verh;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rez_x = verh.transform.position.x - niz.transform.position.x;
        rez_y = verh.transform.position.y - niz.transform.position.y;
        rez_z = verh.transform.position.z - niz.transform.position.z;
        lenght = Mathf.Sqrt((rez_x * rez_x) + (rez_y * rez_y) + (rez_z * rez_z));
        if (lenght == 0)
        {
            angle = 0;
        }
        else
        {
            angle = (float)(Mathf.Acos(rez_y / lenght) * 57.2958);
        }
        rot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);
    }
}
