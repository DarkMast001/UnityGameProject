using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load_scenes : Shuttle_settings
{
    public GameObject scroll;

    public void SceneLoading()
    {
        scroll.SetActive(false);
        for (int i = 0; i < modules.Count; i++)
        {
            //print(modules[i]);
            modules[i].AddComponent<FixedJoint>();
            modules[i].GetComponent<Rigidbody>().isKinematic = false;
            weight_modules += modules[i].GetComponent<Rigidbody>().mass;
            if (i == 1)
            {
                FixedJoint fj_1 = modules[i - 1].GetComponent<FixedJoint>();
                fj_1.connectedBody = modules[i].GetComponent<Rigidbody>();
            }
           // else if (i > 1) 
            //{
                FixedJoint fx = modules[i].GetComponent<FixedJoint>();
                fx.connectedBody = modules[0].GetComponent<Rigidbody>();
            //}
            if (engines.Contains(modules[i]))
            {
                modules[i].AddComponent<RocketStart>();
            }
            /*if (i + 1 == modules.Count && modules[i].GetComponent<FixedJoint>() == null)
            {
                modules[i].AddComponent<RocketStart>();
                modules[i].AddComponent<FixedJoint>();
                FixedJoint fj_1 = modules[i].GetComponent<FixedJoint>();
                fj_1.connectedBody = modules[0].GetComponent<Rigidbody>();
            }
            else
            {
                if (!engines.Contains(modules[i]) && !engines.Contains(modules[i + 1]))
                {
                    if (modules[i + 1].GetComponent<FixedJoint>() == null)
                    {
                        modules[i + 1].AddComponent<FixedJoint>();
                        FixedJoint fj_2 = modules[i + 1].GetComponent<FixedJoint>();
                        fj_2.connectedBody = modules[0].GetComponent<Rigidbody>();
                    }
                    if (modules[i].GetComponent<FixedJoint>() == null)
                    {
                        modules[i].AddComponent<FixedJoint>();
                        FixedJoint fj_1 = modules[i].GetComponent<FixedJoint>();
                        FixedJoint fj_2 = modules[i + 1].GetComponent<FixedJoint>();
                        fj_1.connectedBody = modules[i + 1].GetComponent<Rigidbody>();
                        fj_2.connectedBody = modules[0].GetComponent<Rigidbody>();
                    }
                }
                else if (modules.Contains(modules[i]))
                {
                    modules[i].AddComponent<FixedJoint>();
                    modules[i].AddComponent<RocketStart>();
                    FixedJoint fj_1 = modules[i].GetComponent<FixedJoint>();
                    fj_1.connectedBody = modules[0].GetComponent<Rigidbody>();
                }
            }*/
        }

        GameObject rotated_point = modules[0];
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
