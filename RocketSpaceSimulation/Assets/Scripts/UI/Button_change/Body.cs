using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject ui_cabin;
    public GameObject ui_body;
    public void ChangeCanvas()
    {
        ui_cabin.SetActive(false);
        ui_body.SetActive(true);
    }
}
