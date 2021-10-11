using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_create : MonoBehaviour
{
    public GameObject Object;
    public void CreateObj()
    {
        Instantiate(Object, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
