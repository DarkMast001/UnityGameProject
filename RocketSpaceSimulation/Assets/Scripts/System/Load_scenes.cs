using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load_scenes : MonoBehaviour
{
    public GameObject scroll;
    public GameObject shuttle_settings;

    public void SceneLoading()
    {
        scroll.SetActive(false);
        for (int i = 0; i < shuttle_settings.GetComponent<Shuttle_settings>().modules.Count; i++)
        {
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
