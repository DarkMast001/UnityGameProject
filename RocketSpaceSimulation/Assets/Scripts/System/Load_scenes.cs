using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_scenes : Shuttle_settings
{
    //Shuttle_settings settings;

    public void SceneLoading()
    {
        //startModule.AddComponent<Rigidbody>();
        /*for(int i = 0; i < engines.Count; i++)
        {
            engines[i].AddComponent<RocketStart>();
            engines[i].AddComponent<Rigidbody>();
        }*/

        for (int i = 0; i < modules.Count; i++)
        {
            //print(modules[i + 1]);
            if (i + 1 == modules.Count)
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
                else if (engines.Contains(modules[i]))
                {
                    modules[i].AddComponent<FixedJoint>();
                    modules[i].AddComponent<RocketStart>();
                    FixedJoint fj_1 = modules[i].GetComponent<FixedJoint>();
                    fj_1.connectedBody = modules[0].GetComponent<Rigidbody>();
                }
            }
        }

        //startModule.AddComponent<RocketStart>();
        /*if (isEngineHas)
        {
            SceneManager.LoadScene(1);
        }*/
    }
    public void HangarLoading()
    {
        SceneManager.LoadScene(0);
    }
}
