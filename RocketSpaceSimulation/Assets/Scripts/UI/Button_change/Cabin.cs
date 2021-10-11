using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabin : MonoBehaviour
{
    public GameObject ui_cabin;
    public GameObject ui_body;
    public void ChangeCanvas()
    {
        ui_cabin.SetActive(true);
        ui_body.SetActive(false);
    }
}
