using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabin_model_ui : MonoBehaviour
{
    public GameObject ui_cabin;
    public GameObject ui_body;
    public GameObject ui_engine;
    public void ChangeCanvas()
    {
        ui_body.SetActive(false);
        ui_cabin.SetActive(true);
        ui_engine.SetActive(false);
    }
}
