using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilizator_model_ui : MonoBehaviour
{
    public GameObject ui_cabin;
    public GameObject ui_body;
    public GameObject ui_engine;
    public GameObject ui_stabilizer;
    public void ChangeCanvas()
    {
        ui_body.SetActive(false);
        ui_cabin.SetActive(false);
        ui_engine.SetActive(false);
        ui_stabilizer.SetActive(true);
    }
}
