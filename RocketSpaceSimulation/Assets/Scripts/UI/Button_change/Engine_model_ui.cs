using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_model_ui : MonoBehaviour
{
    public GameObject ui_cabin;
    public GameObject ui_body;
    public GameObject ui_engine;
    public GameObject ui_stabilizer;
    public void ChangeCanvas()
    {
        ui_body.SetActive(false);
        ui_cabin.SetActive(false);
        ui_engine.SetActive(true);
        ui_stabilizer.SetActive(false);
    }
}