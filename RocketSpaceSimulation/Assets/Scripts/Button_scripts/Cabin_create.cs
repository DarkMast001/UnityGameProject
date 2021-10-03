using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabin_create : MonoBehaviour
{
    public GameObject cabinObject;
    public void CreateObj()
    {
        Instantiate(cabinObject, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
