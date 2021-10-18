using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_scenes : Shuttle_settings
{
    //Shuttle_settings settings;

    public void SceneLoading()
    {
        if (isEngineHas)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void HangarLoading()
    {
        SceneManager.LoadScene(0);
    }
}
