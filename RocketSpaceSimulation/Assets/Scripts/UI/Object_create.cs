using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_create : MonoBehaviour
{
    public GameObject Object;
    public bool isMainObject = false;
    public void CreateObj()
    {
        Instantiate(Object, new Vector3(0, 1, 0), Quaternion.Euler(-90, 0, 0));
        Object.tag = "Support";
    }
}
