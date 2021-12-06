using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load_scenes : MonoBehaviour
{
    public GameObject scroll;
    public GameObject shuttle_settings;
    public GameObject windDirection;
    public GameObject windArea;
    public GameObject modelChoise;

    public GameObject rotationPoint;
    public GameObject tmp_rotate;

    //public GameObject normalAngle;
    //public GameObject normalAngleMain;

    public float diractionX;
    public float diractionY;

    private void Start()
    {
        windArea = GameObject.FindGameObjectWithTag("windArea");
    }

    public void SceneLoading()
    {
        shuttle_settings.GetComponent<Shuttle_settings>().gameIsStart = true;
        modelChoise.SetActive(false);
        //normalAngle.SetActive(true);
        //normalAngleMain.SetActive(true);
        windDirection.SetActive(true);
        windDirection.transform.rotation = Quaternion.Euler(-90, 0, Random.Range(0, 360));
        if(windDirection.transform.eulerAngles.y >= 0)
        {
            diractionX = Mathf.Sin(windDirection.transform.eulerAngles.y - 270);
            diractionY = Mathf.Cos(windDirection.transform.eulerAngles.y - 270);
            //print(windDirection.transform.eulerAngles.y - 270);
        }
        else
        {
            diractionX = Mathf.Sin((270 - windDirection.transform.eulerAngles.y) * -1);
            diractionY = Mathf.Cos((270 - windDirection.transform.eulerAngles.y) * -1);
            //print((270 - windDirection.transform.eulerAngles.y) * -1);
        }
        windArea.GetComponent<WindArea>().direction.x = -diractionX;
        windArea.GetComponent<WindArea>().direction.z = -diractionY;
        //print(windDirection.transform.eulerAngles.y);

        scroll.SetActive(false);
        rotationPoint.SetActive(true);
        tmp_rotate.SetActive(true);
        shuttle_settings.GetComponent<Shuttle_settings>().modules[0].AddComponent<ugol>().rot = rotationPoint;
        for (int i = 0; i < shuttle_settings.GetComponent<Shuttle_settings>().modules.Count; i++)
        {
            shuttle_settings.GetComponent<Shuttle_settings>().modules[i].AddComponent<WindModules>();
            Ray ray = new Ray(shuttle_settings.GetComponent<Shuttle_settings>().modules[i].transform.position, transform.up);
            if (!Physics.Raycast(ray, 100))
            {
                shuttle_settings.GetComponent<Shuttle_settings>().surface_area += 1;
            }
            shuttle_settings.GetComponent<Shuttle_settings>().modules[i].AddComponent<FixedJoint>().breakForce = 10000;
            shuttle_settings.GetComponent<Shuttle_settings>().modules[i].GetComponent<Rigidbody>().isKinematic = false;
            shuttle_settings.GetComponent<Shuttle_settings>().weight_modules += shuttle_settings.GetComponent<Shuttle_settings>().modules[i].GetComponent<Rigidbody>().mass;
            if (i == 1)
            {
                FixedJoint fj_1 = shuttle_settings.GetComponent<Shuttle_settings>().modules[i - 1].GetComponent<FixedJoint>();
                fj_1.connectedBody = shuttle_settings.GetComponent<Shuttle_settings>().modules[i].GetComponent<Rigidbody>();
            }
           // else if (i > 1) 
            //{
                FixedJoint fx = shuttle_settings.GetComponent<Shuttle_settings>().modules[i].GetComponent<FixedJoint>();
                fx.connectedBody = shuttle_settings.GetComponent<Shuttle_settings>().modules[0].GetComponent<Rigidbody>();
            //}
            if (shuttle_settings.GetComponent<Shuttle_settings>().engines.Contains(shuttle_settings.GetComponent<Shuttle_settings>().modules[i]))
            {
                shuttle_settings.GetComponent<Shuttle_settings>().modules[i].AddComponent<RocketStart>();
            }
        }

        GameObject rotated_point = shuttle_settings.GetComponent<Shuttle_settings>().modules[0];
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.GetComponent<CameraRotateAround>().target = rotated_point.transform;

        camera.GetComponent<Numeratic_parametors>().rb_for_speed = rotated_point.GetComponent<Rigidbody>();
        camera.GetComponent<Numeratic_parametors>().haight_obj = rotated_point;
        // SceneManager.LoadScene(1);
    }
    public void HangarLoading()
    {
        SceneManager.LoadScene(0);
    }
}
